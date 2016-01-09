using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;
using DataUtilities;

namespace GapsEngine
{
	public class GapCalculator : IGapCalculator
	{
		IList<IDataItem> _dataSource;
		IList<IGapItem> _values;
		int _lastCalculatedIndex, _backupIndex;

		public GapCalculator()
		{
			Initialize(null, null);
		}

		#region IGapCalculator Members

		public void Initialize(IList<IDataItem> dataSource, IList<IGapItem> values)
		{
			_values = values;

			Reset(dataSource);
		}

		public void Reset(IList<IDataItem> dataSource)
		{
			_dataSource = dataSource;

			_lastCalculatedIndex = _backupIndex = -1;

			if (_dataSource != null)
				Calculate(true);
		}

		public void Calculate(bool dataAdded)
		{
			System.Diagnostics.Debug.Assert(_dataSource != null);

			if (_dataSource == null)
			{
				return;
			}
			else if (_dataSource.Count == 0)
			{
				return;
			}
			else if (_dataSource.Count == 1)
			{
				_lastCalculatedIndex = 0;
				return;
			}
			else if (_lastCalculatedIndex >= _dataSource.Count)
				throw new ArgumentOutOfRangeException();

			if (!dataAdded)
			{
				_lastCalculatedIndex = _backupIndex;
			}
			else
			{
				_backupIndex = _lastCalculatedIndex;
			}

			// Remove current gap and recalculate it
			if (!dataAdded && (_values.Count > 0) && (_values[_values.Count - 1].X == _lastCalculatedIndex + 1))
			{
				_values.RemoveAt(_values.Count - 1);
			}

			for (; _lastCalculatedIndex < _dataSource.Count - 1; _lastCalculatedIndex++)
			{
				if (_dataSource[_lastCalculatedIndex].High < _dataSource[_lastCalculatedIndex + 1].Low)
				{
					Gap gap = new Gap(true, GapTypes.NotSet, _lastCalculatedIndex + 1, _dataSource[_lastCalculatedIndex].High, _dataSource[_lastCalculatedIndex + 1].Low);
					_values.Add(gap);
				}
				else if (_dataSource[_lastCalculatedIndex].Low > _dataSource[_lastCalculatedIndex + 1].High)
				{
					Gap gap = new Gap(true, GapTypes.NotSet, _lastCalculatedIndex + 1, _dataSource[_lastCalculatedIndex + 1].High, _dataSource[_lastCalculatedIndex].Low);
					_values.Add(gap);
				}
			}
		}

		public IList<IGapItem> Values 
		{
			get { return _values; }
		}

		#endregion
	}
}
