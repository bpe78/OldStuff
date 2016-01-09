using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessingService
{
	public class Trendline : ChartElement
	{
		public int X1 { get; protected set; }
		public double Y1 { get; protected set; }
		public int X2 { get; protected set; }
		public double Y2 { get; protected set; }

		public Trendline(int x1, decimal y1, int x2, decimal y2)
			: this(x1, (double)y1, x2, (double)y2)
		{
		}

		public Trendline(int x1, double y1, int x2, double y2)
			: base(ElementType.Trendline)
		{
			X1 = x1;
			Y1 = y1;
			X2 = x2;
			Y2 = y2;
		}
	}
}
