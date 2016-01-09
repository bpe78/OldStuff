using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;

namespace MovingAverageEngine
{
	public class ExponentialMACalculator : IMovingAverageCalculator
	{
		private double _currentEMA, _backupCurrentEMA, _previousEMA, _backupPreviousEMA;
		private int _lastIndex, _backupIndex;
		private double _coeff;

		#region Constructors

		public ExponentialMACalculator()
		{
			Initialize(0);
		}

		public ExponentialMACalculator(int period)
		{
			Initialize(period);
		}

		#endregion

		#region IMovingAverageCalculator Members

		public int Period { get; private set; }

		public void Initialize(int period)
		{
			this.Period = period;

			_coeff = 2.0 / (1 + this.Period);

			Reset();
		}

		public void Reset()
		{
			this._currentEMA = this._backupPreviousEMA = this._backupCurrentEMA = 0;
			this._lastIndex = this._backupIndex = 0;
		}

		public double Calculate(double newValue, bool isAddedOrChanged)
		{
			if (isAddedOrChanged)
			{
				this._backupCurrentEMA = this._currentEMA;
				this._backupPreviousEMA = this._previousEMA;
				this._backupIndex = this._lastIndex;
			}
			else
			{
				this._currentEMA = this._backupCurrentEMA;
				this._previousEMA = this._backupPreviousEMA;
				this._lastIndex = this._backupIndex;
			}

			double retVal;

			if (this._lastIndex < this.Period - 1)
			{
				this._currentEMA += newValue;

				retVal = 0.0;
			}
			else if (this._lastIndex == this.Period - 1)
			{
				this._currentEMA += newValue;

				retVal = this._currentEMA / this.Period;
			}
			else
			{
				this._currentEMA = (newValue - _previousEMA) * _coeff + _previousEMA;

				retVal = this._currentEMA;
			}
			this._lastIndex++;

			_previousEMA = retVal;

			return retVal;
		}

		#endregion
	}

}
