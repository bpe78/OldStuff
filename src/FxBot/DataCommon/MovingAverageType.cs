using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCommon
{
	public enum MovingAverageType
	{
		NotSet,
		Simple,
		Exponential,
		Weighted,
		Modified,
		SimpleMovingMedian
	}
}
