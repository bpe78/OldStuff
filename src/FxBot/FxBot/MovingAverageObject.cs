using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxBot
{
	public class MovingAverageObject
	{
		public int Period { get; set; }
		public PriceFormula PriceType { get; set; }

		public MovingAverageObject()
		{
			Period = 1;
			PriceType = PriceFormula.Close;
		}
	}

	public enum PriceFormula
	{
		Close,
		Open,
		TypicalPrice,
		MedianPrice
	}
}
