using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataCommon;

namespace GapsEngine
{
	public class Gap : IGapItem
	{
		//TODO: link the gap object with the gapping sessions ???
		public int X { get; private set; }
		public double Top { get; private set; }
		public double Bottom { get; private set; }
		public bool IsFullGap { get; private set; }
		public GapTypes GapType { get; private set; }
		public GapSize Size { get; private set; }

		public Gap(bool isFull, GapTypes type, int x, double top, double bottom)
		{
			X = x;
			Top = top;
			Bottom = bottom;
			IsFullGap = isFull;
			GapType = type;
		}
	}

}
