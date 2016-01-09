using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using ProcessingService;

namespace PresentationLayer
{
	public class TrendlineElement : Shape
	{
		private ChartCanvas _canvas;
		int _x1, _x2;
		double _y1, _y2;

		public TrendlineElement(ChartCanvas canvas, Trendline trendline)
			: this(canvas, trendline.X1, trendline.Y1, trendline.X2, trendline.Y2)
		{
		}

		public TrendlineElement(ChartCanvas canvas, int x1, decimal y1, int x2, decimal y2)
			: this(canvas, x1, (double)y1, x2, (double)y2)
		{
		}

		public TrendlineElement(ChartCanvas canvas, int x1, double y1, int x2, double y2)
		{
			_canvas = canvas;

			_x1 = x1;
			_y1 = y1;
			_x2 = x2;
			_y2 = y2;

			//Stroke = Brushes.White;
			Stroke = Brushes.Blue;
			StrokeThickness = 1;

			SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
			System.Windows.Controls.Canvas.SetZIndex(this, 2);
		}

		LineGeometry _geometry = null;

		protected override Geometry DefiningGeometry
		{
			get
			{
				if (_geometry == null)
				{
					_geometry = new LineGeometry(new Point(_canvas.X(_x1, RelativePosition.Middle), _canvas.Y(_y1)),
																			 new Point(_canvas.X(_x2, RelativePosition.Middle), _canvas.Y(_y2)));
				}

				return _geometry;
			}
		}
	}
}
