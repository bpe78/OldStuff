using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrendEngine
{
	public class TradingRange
	{
		public int X1 { get; private set; }
		public int X2 { get; private set; }

		public double Min { get; private set; }
		public double Max { get; private set; }

		public TradingRange(int x1, int x2, double min, double max)
		{
			X1 = x1;
			X2 = x2;

			Min = min;
			Max = max;
		}
	}
}
