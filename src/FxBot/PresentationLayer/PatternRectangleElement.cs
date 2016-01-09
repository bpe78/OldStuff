using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace PresentationLayer
{
	public class PatternRectangleElement : Shape
	{
		private ChartCanvas _canvas;

		public int Left { get; set; }
		public double Top { get; set; }
		public int Right { get; set; }
		public double Bottom { get; set; }

		public PatternRectangleElement(ChartCanvas canvas, int left, double top, int right, double bottom)
		{
			_canvas = canvas;

			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;

			Fill = Brushes.Plum;
			Stroke = Brushes.Black;
			StrokeThickness = 1;
			Opacity = 0.7;

			SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
			System.Windows.Controls.Canvas.SetZIndex(this, 0);
		}

		Geometry _geometry = null;
		protected override Geometry DefiningGeometry
		{
			get
			{
				if (_geometry == null)
				{
/*
					RectangleGeometry body = new RectangleGeometry(new Rect(new Point(_canvas.X(this.Left, RelativePosition.Before) + StrokeThickness / 2.0, 0.90 * _canvas.Y(this.Top)),
																																	new Point(_canvas.X(this.Right, RelativePosition.After) - StrokeThickness / 2.0, 1.01 * _canvas.Y(this.Bottom))));
*/
					RectangleGeometry body = new RectangleGeometry(new Rect(new Point(_canvas.X(this.Left, RelativePosition.Before) + StrokeThickness / 2.0, _canvas.Y(this.Top)),
																																	new Point(_canvas.X(this.Right, RelativePosition.After) - StrokeThickness / 2.0, _canvas.Y(this.Bottom))));
					body.RadiusX = body.RadiusY = 10;
					_geometry = body;
				}
				return _geometry;
			}
		}
	}
}
