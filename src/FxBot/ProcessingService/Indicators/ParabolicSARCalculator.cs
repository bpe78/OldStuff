using System;
using System.Collections.Generic;
using System.Text;

namespace IndicatorsEngine
{
	public class ParabolicSARCalculator :IIndicatorCalculator
	{
		#region IIndicatorCalculator Members

		public void Initialize(int period, IList<DataCommon.IDataItem> dataSource, IList<double> values)
		{
			throw new NotImplementedException();
		}

		public void Reset(IList<DataCommon.IDataItem> dataSource)
		{
			throw new NotImplementedException();
		}

		public double Calculate(bool dataAdded)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
