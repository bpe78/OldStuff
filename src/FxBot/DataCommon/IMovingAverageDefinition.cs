using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCommon
{
	public interface IMovingAverageDefinition
	{
		MovingAverageType MovingAverageType { get; }
		PriceFormula Formula { get; }
		int Period { get; }
	}
}
