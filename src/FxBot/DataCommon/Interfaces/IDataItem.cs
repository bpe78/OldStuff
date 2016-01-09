using System;
using System.Collections.Generic;
using System.Text;

namespace DataCommon
{
	public interface IDataItem
	{
		DateTime Date { get; }
		double Open { get; }
		double High { get; }
		double Low { get; }
		double Close { get; }
		long Volume { get; }
		long OpenInterest { get; }
	}
}
