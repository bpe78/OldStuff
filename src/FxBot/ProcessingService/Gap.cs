using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessingService
{
	public class Gap : ChartElement
	{
		public int X { get; protected set; }
		public double Top { get; private set; }
		public double Bottom { get; private set; }
		public bool IsFullGap { get; private set; }

		public Gap(int x, double top, double bottom, bool isFull)
			: base(ElementType.Gap)
		{
			X = x;
			Top = top;
			Bottom = bottom;
			IsFullGap = isFull;
		}
	}
}
