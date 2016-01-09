using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessingService
{
	public class ChartElement
	{
		public ElementType ChartElementType { get; protected set; }

		public ChartElement(ElementType type)
		{
			ChartElementType = type;
		}
	}

	public enum ElementType
	{
		Candlestick,
		Trendline,
		TradingRange,
		MovingAverage,
		Gap
	}
}
