using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessingService
{
	public class Candlestick : ChartElement
	{
		private const int _scale = 100000;

		public int X { get; protected set; }
		public double O { get; protected set; }
		public double H { get; protected set; }
		public double L { get; protected set; }
		public double C { get; protected set; }

		public Candlestick(int x, int o, int h, int l, int c)
			: this(x, ((double)o) / _scale, ((double)h) / _scale, ((double)l) / _scale, ((double)c) / _scale)
		{
		}

		public Candlestick(int x, decimal o, decimal h, decimal l, decimal c)
			: this(x, (double)o, (double)h, (double)l, (double)c)
		{
		}

		public Candlestick(int x, double o, double h, double l, double c)
			:base(ElementType.Candlestick)
		{
			X = x;
			O = o;
			H = h;
			L = l;
			C = c;
		}
	}
}
