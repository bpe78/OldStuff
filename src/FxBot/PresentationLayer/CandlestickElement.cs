using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using ProcessingService;

namespace PresentationLayer
{
	public class CandlestickElement : Shape
	{
		private ChartCanvas _canvas;
		public int X { get; set; }
		public double O { get; set; }
		public double H { get; set; }
		public double L { get; set; }
		public double C { get; set; }

		public CandlestickElement(ChartCanvas canvas, Candlestick candlestick)
			: this(canvas, candlestick.X, candlestick.O, candlestick.H, candlestick.L, candlestick.C)
		{
		}

		public CandlestickElement(ChartCanvas canvas, int x, decimal o, decimal h, decimal l, decimal c)
			: this(canvas, x, (double)o, (double)h, (double)l, (double)c)
		{
		}

		public CandlestickElement(ChartCanvas canvas, int x, double o, double h, double l, double c)
		{
			_canvas = canvas;

			X = x;
			O = o;
			H = h;
			L = l;
			C = c;

			Stroke = Brushes.Black;
			//Stroke = Brushes.White;
			StrokeThickness = 1.0;

			if (O == C)
				Fill = Brushes.Black;
			else if (O < C)
				Fill = Brushes.Green;
			else
				Fill = Brushes.Red;
			//Stroke = Fill;

			SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
			System.Windows.Controls.Canvas.SetZIndex(this, 1);
		}

		GeometryGroup group = null;
		LineGeometry upperShadow = new LineGeometry();
		RectangleGeometry body = new RectangleGeometry();
		LineGeometry lowerShadow = new LineGeometry();

		protected override Geometry DefiningGeometry
		{
			get
			{
				double min = Math.Min(this.O, this.C), max = Math.Max(this.O, this.C);

				upperShadow.StartPoint = new Point(_canvas.X(this.X, RelativePosition.Middle) - StrokeThickness / 2.0, _canvas.Y(this.H));
				upperShadow.EndPoint = new Point(_canvas.X(this.X, RelativePosition.Middle) - StrokeThickness / 2.0, _canvas.Y(max));

				body.Rect = new Rect(new Point(_canvas.X(this.X, RelativePosition.Left) + StrokeThickness / 2.0, _canvas.Y(this.O)),
														 new Point(_canvas.X(this.X, RelativePosition.Right) - StrokeThickness / 2.0, _canvas.Y(this.C)));

				lowerShadow.StartPoint = new Point(_canvas.X(this.X, RelativePosition.Middle) - StrokeThickness / 2.0, _canvas.Y(min));
				lowerShadow.EndPoint = new Point(_canvas.X(this.X, RelativePosition.Middle) - StrokeThickness / 2.0, _canvas.Y(this.L));

				if (group == null)
				{
					group = new GeometryGroup();
					group.Children.Add(upperShadow);
					group.Children.Add(body);
					group.Children.Add(lowerShadow);
				}

				return group;
			}
		}
	}
}
