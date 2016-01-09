using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;

namespace ProcessingService
{
	public class MovingAverage : ChartElement
	{
		public int[] X { get; protected set; }
		public double[] Y { get; protected set; }

		public MovingAverage(int[] x, double[] y)
			: base(ElementType.MovingAverage)
		{
			X = x;
			Y = y;
		}

		public MovingAverage(int x1, int x2, IList<double> y)
			: base(ElementType.MovingAverage)
		{
			X = new int[x2 - x1 + 1];
			Y = new double[x2 - x1 + 1];
			for (int i = x1; i <= x2; i++)
			{
				X[i - x1] = i;
				Y[i - x1] = y[i];
			}
		}

	}
}
