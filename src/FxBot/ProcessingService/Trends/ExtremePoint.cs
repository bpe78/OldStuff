using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrendEngine
{
	public class ExtremePoint
	{
		public int X { get; set; }
		public double Value { get; set; }
		public ExtremePointType ExtremeType { get; private set; }

		public ExtremePoint(int x, double value, ExtremePointType extremeType)
		{
			X = x;
			Value = value;
			ExtremeType = extremeType;
		}
	}

	public enum ExtremePointType
	{
		Min,
		Max
	}
}
