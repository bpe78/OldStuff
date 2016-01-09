using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessingService
{
	public class TradingRangeBox : ChartElement
	{
		public int X1 { get; protected set; }
		public int X2 { get; protected set; }

		public double Min { get; protected set; }
		public double Max { get; protected set; }

		public TradingRangeBox(int x1, int x2, double min, double max)
			: base(ElementType.TradingRange)
		{
			X1 = x1;
			X2 = x2;
			Min = min;
			Max = max;
		}
	}}
