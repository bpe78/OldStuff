using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ProcessingService;


namespace PresentationLayer
{
	public class ChartCanvas : Canvas
	{
		private DoubleCollection _gridPattern;
		public ChartCanvas()
		{
			RebuildDisabled = true;

			//Background = new SolidColorBrush(Color.FromArgb(0xf0, 0x3f, 0x3f, 0x3f));
			GradientStopCollection gradient = new GradientStopCollection();
			gradient.Add(new GradientStop(Color.FromRgb(203, 231, 227), 0));
			gradient.Add(new GradientStop(Color.FromRgb(241, 230, 168), 0.6));
			gradient.Add(new GradientStop(Color.FromRgb(236, 213, 186), 1));
			LinearGradientBrush back = new LinearGradientBrush(gradient, new Point(0,0), new Point(0, 1));
			Background = back;
			Offset = 0;
			XRange = 50;
			CandleWidth = 9;
			CandleSpacing = 3;
			YMin = 0;
			YMax = 100;

			LeftMargin = 10;
			RightMargin = 40;
			TopMargin = 10;
			BottomMargin = 10;

			_gridPattern = new DoubleCollection(2);
			_gridPattern.Add(5);
			_gridPattern.Add(5);

			ShowGridLines();
			this.PreviewMouseLeftButtonDown += CustomCanvas_PreviewMouseLeftButtonDown;
			this.PreviewMouseLeftButtonUp += CustomCanvas_PreviewMouseLeftButtonUp;
			this.PreviewMouseMove += CustomCanvas_PreviewMouseMove;

			this.SizeChanged += ChartCanvas_SizeChanged;

			RebuildDisabled = false;
		}


		public IDrawingObjectsProvider DrawingObjectsProvider { get; set; }

		private bool _rebuildDisabled;
		private bool RebuildDisabled
		{
			get
			{
				return _rebuildDisabled;
			}
			set
			{
				lock (this)
				{
					_rebuildDisabled = value;
				}
			}
		}

		public void RebuildChildren(bool updateOffset)
		{
			if(System.Threading.Monitor.TryEnter(this))
			{
				if ((ActualWidth == 0) || (ActualHeight == 0))
					return;

				if ((DrawingObjectsProvider != null) && !RebuildDisabled)
				{
					RebuildDisabled = true;

					this.Children.Clear();

					Rectangle r = new Rectangle();
					r.Stroke = Brushes.White;
					r.StrokeThickness = 1;
					r.Width = ActualWidth - LeftMargin - RightMargin + 2;
					r.Height = ActualHeight - TopMargin - BottomMargin + 2;
					Canvas.SetLeft(r, LeftMargin - 1);
					Canvas.SetTop(r, TopMargin - 1);
					this.Children.Add(r);

					RebuildHorizontalLines();
					RebuildVerticalLines();

					YMin = double.MaxValue;
					YMax = double.MinValue;
					XMax = DrawingObjectsProvider.Count;
					if (updateOffset)
						Offset = Math.Max(0, XMax - XRange);
					int lastX1 = 0;
					foreach (ChartElement element in DrawingObjectsProvider.GetDrawingObjects(Offset, Math.Min(Offset + XRange, XMax) - 1))
					{
						Shape shape = null;
						switch (element.ChartElementType)
						{
							case ElementType.Candlestick:
								{
									Candlestick candle = element as Candlestick;
									shape = new CandlestickElement(this, candle);

									YMin = Math.Min(YMin, candle.L);
									YMax = Math.Max(YMax, candle.H);
								} break;

							case ElementType.Trendline:
								{
									shape = new TrendlineElement(this, element as Trendline);
									if (((Trendline)element).X1 < lastX1)
									{
										shape.Stroke = Brushes.OrangeRed;
									}
									else
										shape.StrokeThickness = 2;

									lastX1 = Math.Max(lastX1, ((Trendline)element).X1);
								} break;

							case ElementType.TradingRange:
								{
									TradingRangeBox tr = element as TradingRangeBox;
									shape = new PatternRectangleElement(this, tr.X1, tr.Max, tr.X2, tr.Min);
								} break;

							case ElementType.MovingAverage:
								{
									MovingAverage ma = element as MovingAverage;
									shape = new MovingAverageElement(this, ma);

									for (int i = 0; i < ma.Y.Length; i++)
									{
										if (ma.Y[i] > 0)
										{
											YMin = Math.Min(YMin, ma.Y[i]);
											YMax = Math.Max(YMax, ma.Y[i]);
										}
									}
								} break;

							case ElementType.Gap:
								{
									shape = new GapElement(this, element as Gap);
								} break;

							default: throw new ArgumentOutOfRangeException();
						}

						this.Children.Add(shape);
					}

					RebuildDisabled = false;
				}

				System.Threading.Monitor.Exit(this);
			}
		}

		private void RebuildHorizontalLines()
		{
			const int lines = 10;
			for (int i = 0; i <= lines; i++)
			{
				double y = YMin + i * (YMax - YMin) / lines;
				
				// Draw the horizontal line
				Line line = new Line();
				line.X1 = X(Offset, RelativePosition.Before) - 1;
				line.X2 = X(Offset + XRange, RelativePosition.After) + 1;
				line.Y1 = Y(y);
				line.Y2 = Y(y);
				line.Stroke = Brushes.White;
				line.StrokeDashArray = _gridPattern;
				line.StrokeThickness = 1;
				this.Children.Add(line);


				// Draw the label
				TextBlock tb = new TextBlock();
				tb.Text = y.ToString("#.#####");
				tb.Foreground = Brushes.White;
				tb.Background = Brushes.Blue;
				Size s = new Size(ActualWidth, ActualHeight);
				tb.Measure(s);
				Canvas.SetLeft(tb, X(Offset + XRange, RelativePosition.After) + 5);
				Canvas.SetTop(tb, Y(y) - tb.DesiredSize.Height / 2.0);
				this.Children.Add(tb);
			}
		}

		private void RebuildVerticalLines()
		{
			for (int i = Offset; i <= Offset + XRange; i+= 10)
			{
				// Draw the vertical line
				Line line = new Line();
				line.X1 = line.X2 = X(i, RelativePosition.Before);
				line.Y1 = Y(YMin);
				line.Y2 = Y(YMax);
				line.Stroke = Brushes.White;
				line.StrokeDashArray = _gridPattern;
				line.StrokeThickness = 1;
				this.Children.Add(line);

/*
				// Draw the label
				TextBlock tb = new TextBlock();
				tb.Text = y.ToString("#.#####");
				tb.Foreground = Brushes.White;
				tb.Background = Brushes.Blue;
				Size s = new Size(ActualWidth, ActualHeight);
				tb.Measure(s);
				Canvas.SetLeft(tb, X(Offset + XRange, RelativePosition.After) + 5);
				Canvas.SetTop(tb, Y(y) - tb.DesiredSize.Height / 2.0);
				this.Children.Add(tb);
*/
			}
		}


		#region Drawing Helpers

		#region Internal Margins

		double LeftMargin { get; set; }

		double RightMargin { get; set; }

		double TopMargin { get; set; }

		double BottomMargin { get; set; }

		#endregion

		#region X axis

		private int _offset;
		public int Offset
		{
			get
			{
				return _offset;
			}
			set
			{
				if (_offset != value)
				{
					_offset = value;
					RebuildChildren(false);
				}
			}
		}

		private int _xMax;
		public int XMax
		{
			get
			{
				return _xMax;
			}
			set
			{
				if (_xMax != value)
				{
					_xMax = value;
					Offset = Math.Max(0, value - XRange);
					//RebuildChildren();
				}
			}
	 }

		private int _xRange;
		public int XRange
		{
			get
			{
				return _xRange;
			}
			set
			{
				if (_xRange != value)
				{
					_xRange = value;
					RebuildChildren(false);
				}
			}
		}

		private double _candleWidth;
		public double CandleWidth
		{
			get
			{
				return _candleWidth;
			}
			set
			{
				if (_candleWidth != value)
				{
					_candleWidth = value;
					RebuildChildren(false);
				}
			}
		}

		private double _candleSpacing;
		public double CandleSpacing
		{
			get
			{
				return _candleSpacing;
			}
			set
			{
				if (_candleSpacing != value)
				{
					_candleSpacing = value;
					RebuildChildren(false);
				}
			}
		}

		public void CalculateParameters(int n)
		{
			System.Diagnostics.Debug.Assert(false);
			RebuildDisabled = true;
			XRange = n;

			double tmp = (ActualWidth - LeftMargin - RightMargin) / XRange;

			CandleSpacing = Math.Min(5, tmp / 3);
			CandleWidth = tmp - CandleSpacing;

			RebuildDisabled = false;
			RebuildChildren(false);
		}

		public void CalculateParameters(double width, double separator)
		{
			RebuildDisabled = true;

			CandleWidth = width;
			CandleSpacing = separator;
			XRange = (int)Math.Floor((ActualWidth - LeftMargin - RightMargin) / (CandleWidth + CandleSpacing));

			RebuildDisabled = false;
			RebuildChildren(false);
		}

		public double X(int x, RelativePosition position)
		{
			if (x < 0)
				throw new ArgumentException();

			if (x < Offset)
				x = Offset;

			if (x > Offset + XRange - 1)
				x = Offset + XRange - 1;

			double firstSeparator = (ActualWidth - LeftMargin - RightMargin - (XRange * (CandleWidth + CandleSpacing) - CandleSpacing)) / 2.0;
			firstSeparator = Math.Max(firstSeparator, 0);

			double retVal = LeftMargin + firstSeparator;
			retVal += (x - Offset) * (CandleWidth + CandleSpacing);

			switch (position)
			{
				case RelativePosition.Before:
					{
						if (x == Offset)
							retVal -= firstSeparator / 2.0;
						else
							retVal -= CandleSpacing / 2.0;
					} break;

				case RelativePosition.Left:
					{
						// Nothing to do
					} break;

				case RelativePosition.Middle:
					{
						retVal += CandleWidth / 2.0;
					} break;

				case RelativePosition.Right:
					{
						retVal += CandleWidth;
					} break;

				case RelativePosition.After:
					{
						if (x == Offset + XRange - 1)
							retVal += CandleWidth + firstSeparator / 2.0;
						else
							retVal += CandleWidth + CandleSpacing / 2.0;
					} break;

				default: throw new ArgumentOutOfRangeException();
			}

			return retVal;
		}

		#endregion

		#region Y axis

		private double _yMin;
		public double YMin
		{
			get
			{
				return _yMin;
			}
			set
			{
				if (_yMin != value)
				{
					_yMin = value;
					RebuildChildren(false);
				}
			}
		}

		private double _yMax;
		public double YMax
		{
			get
			{
				return _yMax;
			}
			set
			{
				if (_yMax != value)
				{
					_yMax = value;
					RebuildChildren(false);
				}
			}
		}

		public double Y(double y)
		{
			double retVal = ActualHeight - BottomMargin;

			retVal -= (y - YMin) * (ActualHeight - TopMargin - BottomMargin) / (YMax - YMin);

			return retVal;
		}

		#endregion

		#endregion

		#region Panning

		bool _isPanning = false;
		Point _startPosition;

		private void CustomCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (Mouse.Capture(this))
			{
				this.Cursor = Cursors.ScrollWE;

				panX = 0;
				_startPosition = e.GetPosition(this);
				_isPanning = true;
			}
		}

		private void CustomCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (Mouse.Captured == this)
			{
				Mouse.Capture(null);
				this.Cursor = Cursors.Arrow;
				panX = 0;
				_isPanning = false;
			}
		}

		double panX;
		private void CustomCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
		{
			if (_isPanning)
			{
				Point curPos = e.GetPosition(this);
				panX += curPos.X - _startPosition.X;
				int deltaX = (int)(panX / (CandleWidth + CandleSpacing));
				panX -= deltaX * (CandleWidth + CandleSpacing);

				Offset = Math.Min(Math.Max(0, Offset - deltaX), Math.Max(0, XMax - XRange));

				_startPosition = curPos;
			}
		}

		#endregion

		private void ChartCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			CalculateParameters(CandleWidth, CandleSpacing);
			RebuildChildren(false);
		}

		#region Gridlines

		private void ShowGridLines()
		{
/*
			double _tileWidth = 50;
			double _tileHeight = 50;
			double _tileMargin = 10;

			double width = _tileWidth + _tileMargin;
			double height = _tileHeight + _tileMargin;

			Polyline gridCell = new Polyline();
			gridCell.Margin = new Thickness(_tileMargin);
			gridCell.Stroke = Brushes.Blue;
			gridCell.StrokeThickness = 0.5;
			gridCell.Points = new PointCollection(new Point[] { new Point(0, height - 0.1), new Point(width - 0.1, height - 0.1), new Point(width - 0.1, 0) });

			VisualBrush gridLines = new VisualBrush(gridCell);
			gridLines.TileMode = TileMode.Tile;
			gridLines.Viewport = new Rect(0, 0, 1.0, 1.0);
			gridLines.AlignmentX = AlignmentX.Center;
			gridLines.AlignmentY = AlignmentY.Center;

			Rectangle outerRect = new Rectangle();
			outerRect.Width = 100.0;  //can be any size
			outerRect.Height = 100.0;
			outerRect.Fill = gridLines;

			VisualBrush outerVB = new VisualBrush();
			outerVB.Visual = outerRect;
			outerVB.Viewport = new Rect(0, 0, width, height);
			outerVB.ViewportUnits = BrushMappingMode.Absolute;
			outerVB.TileMode = TileMode.Tile;

			this.Background = outerVB;
*/
		}

		#endregion
	}
}
