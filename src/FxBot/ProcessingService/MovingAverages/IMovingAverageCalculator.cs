using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;

namespace MovingAverageEngine
{
	public interface IMovingAverageCalculator
	{
		int Period { get; }
		void Initialize(int period);
		void Reset();
		double Calculate(double newValue, bool isAddedOrChanged);
	}

}
