using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;

namespace TrendEngine
{
	public class TrendCalculatorBase
	{
		protected IList<IDataItem> _data = null;

		protected TrendCalculatorBase(IList<IDataItem> data)
		{
			System.Diagnostics.Debug.Assert(data != null);
			_data = data;
		}

		protected double PivotPoint(int session)
		{
			return (double)(_data[session].High + _data[session].Low + _data[session].Close) / 3;
		}

		protected double Open(int session)
		{
			return (double)_data[session].Open;
		}

		protected double Close(int session)
		{
			return (double)_data[session].Close;
		}

		protected double High(int session)
		{
			return (double)_data[session].High;
		}

		protected double Low(int session)
		{
			return (double)_data[session].Low;
		}

		protected bool IsDownSession(int i)
		{
			return (Open(i) >= Close(i));
		}

		protected bool IsUpSession(int i)
		{
			return (Open(i) <= Close(i));
		}

		protected bool IsHigherHigh(int i1, int i2)
		{
			return (High(i1) < High(i2));
		}

		protected bool IsLowerLow(int i1, int i2)
		{
			return (Low(i1) > Low(i2));
		}
	}
}
