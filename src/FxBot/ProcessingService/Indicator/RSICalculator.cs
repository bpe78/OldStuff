using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;


namespace IndicatorsEngine
{
	public class RSICalculator : IIndicatorCalculator
	{
		private IList<IDataItem> _dataSource;
		private IList<double> _values;
		private int _lastCalculatedIndex, _backupIndex;
		private int _period;
		private double _gain, _loss, _backupGain, _backupLoss;

		public RSICalculator()
		{
		}

		#region IIndicatorCalculator Members

		public void Initialize(int period, IList<IDataItem> dataSource, IList<double> values)
		{
			_period = period;
			_values = values;

			Reset(dataSource);
		}

		public void Reset(IList<IDataItem> dataSource)
		{
			_dataSource = dataSource;

			_lastCalculatedIndex = _backupIndex = 0;

			_gain = _loss = _backupGain = _backupLoss = 0;
		}

		public double Calculate(bool dataAdded)
		{
			if (!dataAdded)
			{
				_lastCalculatedIndex = _backupIndex;
				_gain = _backupGain;
				_loss = _backupLoss;
			}
			else
			{
				_backupIndex = _lastCalculatedIndex;
				_backupGain = _gain;
				_backupLoss = _loss;
			}

			double gain = 0, loss = 0;
			int x = 1;
			if (_lastCalculatedIndex - x >= 0)
			{
				if (_dataSource[_lastCalculatedIndex].Close > _dataSource[_lastCalculatedIndex - x].Close)
				{
					gain = _dataSource[_lastCalculatedIndex].Close - _dataSource[_lastCalculatedIndex - x].Close;
					loss = 0.0;
				}
				else
				{
					gain = 0.0;
					loss = _dataSource[_lastCalculatedIndex - x].Close - _dataSource[_lastCalculatedIndex].Close;
				}
			}

			double newValue;
			if (_lastCalculatedIndex < _period)
			{
				_gain += gain;
				_loss += loss;

				newValue = 0;
			}
			else if (_lastCalculatedIndex == _period)
			{
				_gain = (_gain + gain) / 14;
				_loss = (_loss + loss) / 14;

				newValue = 100 - 100 / (1 + _gain / _loss);
			}
			else
			{
				_gain = ((_gain * (_period - 1)) + gain) / 14;
				_loss = ((_loss * (_period - 1)) + loss) / 14;

				newValue = 100 - 100 / (1 + _gain/_loss);
			}

			_values[_lastCalculatedIndex] = newValue;
			_lastCalculatedIndex++;

			return newValue;
		}

		#endregion
	}
}
