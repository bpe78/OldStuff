using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataCommon;

namespace GapsEngine
{
	public interface IGapCalculator
	{
		void Initialize(IList<IDataItem> dataSource, IList<IGapItem> values);
		void Reset(IList<IDataItem> dataSource);
		void Calculate(bool dataAdded);
		IList<IGapItem> Values { get; }
	}
}
