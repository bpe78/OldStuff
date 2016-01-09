using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;

namespace MovingAverageEngine
{
	public class SimpleMACalculator : IMovingAverageCalculator
	{
		private double _sum, _backupSum;
		private int _lastIndex, _backupIndex;
		private List<double> _currentValues;

		#region Constructors

		public SimpleMACalculator()
		{
			Initialize(0);
		}

		public SimpleMACalculator(int period)
		{
			Initialize(period);
		}

		#endregion

		#region IMovingAverageCalculator Members

		public int Period { get; private set; }

		public void Initialize(int period)
		{
			this.Period = period;

			this._currentValues = new List<double>(period);

			Reset();
		}

		public void Reset()
		{
			this._sum = this._backupSum = 0;
			this._lastIndex = this._backupIndex = 0;
			this._currentValues.Clear();
		}

		public double Calculate(double newValue, bool isAddedOrChanged)
		{
			if (Period == 1)
				return newValue;

			if (isAddedOrChanged)
			{
				this._backupSum = this._sum;
				this._backupIndex = this._lastIndex;
			}
			else
			{
				this._sum = this._backupSum;
				this._lastIndex = this._backupIndex;
			}

			double retVal;

			if (this._lastIndex < this.Period - 1)
			{
				this._sum += newValue;

				retVal = 0.0;
			}
			else
			{
				this._sum += newValue;

				retVal = this._sum / this.Period;

				this._sum -= this._currentValues[0];
			}
			this._lastIndex++;

			// Add (replace with) the new value
			if (isAddedOrChanged)
				this._currentValues.Add(newValue);
			else
				this._currentValues[this._currentValues.Count - 1] = newValue;

			if (isAddedOrChanged && (this._currentValues.Count > this.Period))
			{
				System.Diagnostics.Debug.Assert(isAddedOrChanged);
				//this._sum -= this._currentValues[0];
				this._currentValues.RemoveAt(0);
			}

			return retVal;
		}

		#endregion
	}
}
