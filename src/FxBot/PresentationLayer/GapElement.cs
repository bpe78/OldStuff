using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using ProcessingService;

namespace PresentationLayer
{
	class GapElement : Shape
	{
		private ChartCanvas _canvas;
		int _x;
		double _top, _bottom;
		bool _isFull;

		public GapElement(ChartCanvas canvas, Gap gap)
			: this(canvas, gap.X, gap.Top, gap.Bottom, gap.IsFullGap)
		{
		}

		public GapElement(ChartCanvas canvas, int x, double top, double bottom, bool isFull)
		{
			_canvas = canvas;

			_x = x;
			_top = top;
			_bottom = bottom;
			_isFull = isFull;

			Stroke = Brushes.White;
			StrokeThickness = 1;
			Fill = Brushes.Plum;
			Opacity = 0.7;

			SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
			System.Windows.Controls.Canvas.SetZIndex(this, 1);
		}

		EllipseGeometry _geometry = null;

		protected override Geometry DefiningGeometry
		{
			get
			{
				if (_geometry == null)
				{
					Point center = new Point(_canvas.X(_x, RelativePosition.Before), _canvas.Y((_top + _bottom) / 2));
					double radiusX = _canvas.X(_x, RelativePosition.Right) - _canvas.X(_x, RelativePosition.Before);
					double radiusY = (_canvas.Y(_top) - _canvas.Y(_bottom)) / 2;

					_geometry = new EllipseGeometry(center, radiusX, radiusY);
				}

				return _geometry;
			}
		}
	}
}
