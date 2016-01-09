using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;

namespace TrendEngine
{
	public interface ITrendCalculator
	{
		void Initialize(IList<IDataItem> dataSource, IList<int> values);
		void Reset(IList<IDataItem> dataSource);
		void Calculate(bool dataAdded);
		IList<int> Values { get; }
		IList<ExtremePoint> Trends { get; }
	}
}
