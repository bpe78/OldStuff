using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;

namespace IndicatorsEngine
{
	public interface IIndicatorCalculator
	{
		void Initialize(int period, IList<IDataItem> dataSource, IList<double> values);
		void Reset(IList<IDataItem> dataSource);
		double Calculate(bool dataAdded);
	}
}
