using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using ProcessingService;
using System.Windows.Media;
using System.Windows;

namespace PresentationLayer
{
	public class MovingAverageElement : Shape
	{
		private ChartCanvas _canvas;
		int[] _x;
		double[] _y;

		public MovingAverageElement(ChartCanvas canvas, MovingAverage ma)
			: this(canvas, ma.X, ma.Y)
		{
		}

		public MovingAverageElement(ChartCanvas canvas, int[] x, double[] y)
		{
			_canvas = canvas;

			_x = x;
			_y = y;

			Stroke = Brushes.Magenta;
			StrokeThickness = 1;

			SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
			System.Windows.Controls.Canvas.SetZIndex(this, 1);
		}

		GeometryGroup _geometry = null;

		protected override Geometry DefiningGeometry
		{
			get
			{
				if (_geometry == null)
				{
					_geometry = new GeometryGroup();

					for (int i = 0; i < _x.Length - 1; i++)
					{
						if (_y[i] == 0.0)
							continue;

						LineGeometry line = new LineGeometry(new Point(_canvas.X(_x[i], RelativePosition.Middle), _canvas.Y(_y[i])),
																								 new Point(_canvas.X(_x[i + 1], RelativePosition.Middle), _canvas.Y(_y[i + 1])));
						_geometry.Children.Add(line);
					}
				}

				return _geometry;
			}
		}
	}
}
