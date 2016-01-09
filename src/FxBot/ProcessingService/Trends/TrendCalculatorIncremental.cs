using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;

namespace TrendEngine
{
	public class TrendCalculatorIncremental : ITrendCalculator //TrendCalculatorBase, 
	{
		private bool _trendHasDirection;
		private int _lastCalculatedIndex, _backupIndex;
		private bool _trendIsUp;

		IList<IDataItem> _dataSource = null;
		IList<int> _values;

		List<ExtremePoint> _extremePoints = null;

		public TrendCalculatorIncremental()
		{
			Initialize(null, null);
		}

		#region ITrendCalculator Members

		public void Initialize(IList<IDataItem> dataSource, IList<int> values)
		{
			_values = values;

			Reset(dataSource);
		}

		public void Reset(IList<IDataItem> dataSource)
		{
			_dataSource = dataSource;

			_trendHasDirection = false;
			_lastCalculatedIndex = 0;
			_backupIndex = 0;

			if (_dataSource != null)
				Calculate(true);
		}

		public void Calculate(bool dataAdded)
		{
			if (!dataAdded)
			{
				_lastCalculatedIndex = _backupIndex;
			}
			else
			{
				_backupIndex = _lastCalculatedIndex;
			}

			CalculateExtremes();

			ComposeTrend();

			CreateExtremesList();
		}

		public IList<int> Values
		{
			get { return _values; }
		}

		public IList<ExtremePoint> Trends
		{
			get { return _extremePoints; }
		}

		#endregion

/*
		public void Add(int count)
		{
			for (int i = 0; i < count; i++)
				_values.Add(0);
		}
*/

/*
		private List<ExtremePoint> _tmpExtremes;

		public List<ExtremePoint> CalculateTrends()
		{
			CalculateExtremes();

			ComposeTrend();

			// Tmp stuff
			List<int> oldRanks = new List<int>(_values);

			//FindStrongTrends();

			CreateExtremesList();

			//_tradingRanges = null;
			//FindTradingRanges7();

			_tmpExtremes = _extremePoints;

			_values.Clear();
			_values.AddRange(oldRanks);
			// End Tmp stuff

			CreateExtremesList();

			return _extremePoints;
		}
*/

/*
		public List<ExtremePoint> GetStrongTrends()
		{
			if (_tmpExtremes != null)
				return _tmpExtremes;
			else
				return new List<ExtremePoint>();
		}
*/

		private void CalculateExtremes()
		{
			if (!_trendHasDirection)
			{
				// Calculate the first direction of the trend
				int next = 1;
				while ((next < _dataSource.Count) && !IsHigherHigh(0, next) && !IsLowerLow(0, next))
					next++;
				if (next >= _dataSource.Count)
					return;

				if (IsHigherHigh(0, next) && IsLowerLow(0, next))
				{
					System.Diagnostics.Debug.Assert(false);
					throw new InvalidProgramException();
				}

				if (IsHigherHigh(0, next))
				{
					_values[0] = -1;
					_trendIsUp = true;
				}
				else if (IsLowerLow(0, next))
				{
					_values[0] = 1;
					_trendIsUp = false;
				}

				_trendHasDirection = true;
				_lastCalculatedIndex = next;
			}
			else
			{
				_lastCalculatedIndex = FindExtremePointBackward(2);
				System.Diagnostics.Debug.Assert(_values[_lastCalculatedIndex] != 0);
				_trendIsUp = !(_values[_lastCalculatedIndex] == -1);
			}

			// Reset all subsequent extremes because they will be recalculated
			for (int i = _lastCalculatedIndex; i < _values.Count; i++)
				_values[i] = 0;

			// Calculate using a Higher High/Lower Low algorithm
			for (int i = _lastCalculatedIndex; i < _values.Count; i++)
			{
				int checkPoint = i;

				if (_trendIsUp)
				{
					while (checkPoint < _values.Count - 1)
					{
						// Higher High/Higher Low
						if ((_dataSource[checkPoint].High <= _dataSource[checkPoint + 1].High) &&
								(_dataSource[checkPoint].Low < _dataSource[checkPoint + 1].Low))
						{
							checkPoint++;
						}
						// The difference between highs and lows is NOT in favor of higher high
						else if ((_dataSource[checkPoint].High < _dataSource[checkPoint + 1].High) &&
										 (_dataSource[checkPoint].Low > _dataSource[checkPoint + 1].Low) &&
										 ((_dataSource[checkPoint + 1].High) - _dataSource[checkPoint].High) > (_dataSource[checkPoint].Low - _dataSource[checkPoint + 1].Low))
						{
							checkPoint++;
						}
						// Higher High and Low is higher than previous low
						else if ((_dataSource[checkPoint].High <= _dataSource[checkPoint + 1].High) && 
										 (_dataSource[FindPreviousExtremePoint(checkPoint)].Low < _dataSource[checkPoint + 1].Low))
						{
							checkPoint++;
						}
						else
							break;
					}

					if (checkPoint >= _values.Count)
						break;

					_values[checkPoint] = 1;
				}
				else
				{
					while (checkPoint < _values.Count - 1)
					{
						// Lower High/Lower Low
						if ((_dataSource[checkPoint].Low >= _dataSource[checkPoint + 1].Low) && (_dataSource[checkPoint].High > _dataSource[checkPoint + 1].High))
						{
							checkPoint++;
						}
						// The difference between highs and lows is NOT in favor of lower low
						else if ((_dataSource[checkPoint].High < _dataSource[checkPoint + 1].High) && (_dataSource[checkPoint].Low > _dataSource[checkPoint + 1].Low) &&
										 (_dataSource[checkPoint + 1].High - _dataSource[checkPoint].High) < (_dataSource[checkPoint].Low - _dataSource[checkPoint + 1].Low))
						{
							checkPoint++;
						}
						// Lower Low and High is lower than previous low
						else if ((_dataSource[checkPoint].Low >= _dataSource[checkPoint + 1].Low) &&
										 (_dataSource[FindPreviousExtremePoint(checkPoint)].High > _dataSource[checkPoint + 1].High))
						{
							checkPoint++;
						}
						else
							break;
					}

					if (checkPoint >= _values.Count)
						break;

					_values[checkPoint] = -1;
				}

				_trendIsUp = !_trendIsUp;	// the trend must change
				i = checkPoint;
				_lastCalculatedIndex = i;
			}
		}

		private void ComposeTrend()
		{
			ComposeTrend1();
			//ComposeTrend2();
			ComposeTrend3();
			//ComposeTrend4();
			//ComposeTrend5();
		}

		private void ComposeTrend1()
		{
			// Move the extreme to the most extreme point, if different than the actual extreme
			for (int i = FindExtremePointBackward(2); i < _values.Count - 1; i++)
			{
				int x1 = FindNextExtremePoint(i);
				if (x1 < 0)
					break;

				if (_values[x1] == 1)
				{
					if ((x1 > 0) && (_values[x1 - 1] == 0) && (_dataSource[x1 - 1].High > _dataSource[x1].High))
					{
						_values[x1 - 1] = _values[x1];
						_values[x1] = 0;
					}
					else if ((x1 + 1 < _values.Count) && (_values[x1 + 1] == 0) && (_dataSource[x1].High < _dataSource[x1 + 1].High))
					{
						_values[x1 + 1] = _values[x1];
						_values[x1] = 0;
					}
				}
				else if (_values[x1] == -1)
				{
					if ((x1 > 0) && (_values[x1 - 1] == 0) && (_dataSource[x1 - 1].Low < _dataSource[x1].Low))
					{
						_values[x1 - 1] = _values[x1];
						_values[x1] = 0;
					}
					else if ((x1 + 1 < _values.Count) && (_values[x1 + 1] == 0) && (_dataSource[x1].Low > _dataSource[x1 + 1].Low))
					{
						_values[x1 + 1] = _values[x1];
						_values[x1] = 0;
					}
				}
				else
					// Should never appear
					System.Diagnostics.Debug.Assert(false);
			}
		}
/*
		private void ComposeTrend2()
		{
			// If an extreme low has higher high than the adjacent extreme highs
			for (int i = FindExtremePointBackward(7); i < _values.Count; )
			{
				int x1 = FindNextExtremePoint(i);
				if (x1 < 0)
					break;

				int x2 = FindNextExtremePoint(x1 + 1);
				if (x2 < 0)
					break;

				int x3 = FindNextExtremePoint(x2 + 1);
				if (x3 < 0)
					break;

				int x4 = FindNextExtremePoint(x3 + 1);
				if (x4 < 0)
					break;

				int x5 = FindNextExtremePoint(x4 + 1);
				if (x5 < 0)
					break;

				// extremes 1, 3, 5 are on the same side, extremes 2,4 are on the other side
				if ((_values[x1] == _values[x3]) && (_values[x3] == _values[x5]) && (_values[x2] == _values[x4]) && (_values[x2] != _values[x3]))
				{
					if ((_values[x3] == -1) && IsHigherHigh(x2, x3) && IsHigherHigh(x4, x3) && !IsLowerLow(x1, x3) && !IsLowerLow(x5, x3))
					{
						_values[x3] = _values[x2];
						_values[x2] = _values[x4] = 0;
					}
					else if ((_values[x3] == 1) && IsLowerLow(x2, x3) && IsLowerLow(x4, x3) && !IsHigherHigh(x1, x3) && !IsHigherHigh(x5, x3))
					{
						_values[x3] = _values[x2];
						_values[x2] = _values[x4] = 0;
					}
				}
				else
				{
					System.Diagnostics.Debug.Assert(false, String.Format("x1 = {0}, x2 = {1}, x3 = {2}, x4 = {3}, x5 = {4}, ", x1, x2, x3, x4, x5));
				}

				i = x1 + 1;
			}
		}
*/
		private void ComposeTrend3()
		{
			// Remove an extreme between 2 extremes if they are on consecutive sessions and no higher high / lower low is produced
			for (int i = Math.Max(2, FindExtremePointBackward(2)); i < _values.Count; i++)
			{
				if ((_values[i - 2] == -1) && (_values[i - 1] == 1) && (_values[i] == -1))
				{
					if ((_dataSource[i - 2].Low < _dataSource[i - 1].Low) &&
							(_dataSource[i].Low < _dataSource[i - 1].Low) &&
							(_dataSource[i - 2].High >= _dataSource[i - 1].High) &&
							(_dataSource[i].High >= _dataSource[i - 1].High) &&
							(_dataSource[i - 1].Open >= _dataSource[i - 1].Close))	// Except green sessions
					{
						_values[i - 1] = 0;
						if (_dataSource[i - 2].Low >= _dataSource[i].Low)
							_values[i - 2] = 0;
						else
							_values[i] = 0;
					}
				}
				else if ((_values[i - 2] == 1) && (_values[i - 1] == -1) && (_values[i] == 1))
				{
					if ((_dataSource[i - 2].High > _dataSource[i - 1].High) &&
							(_dataSource[i].High > _dataSource[i - 1].High) &&
							(_dataSource[i - 2].Low <= _dataSource[i - 1].Low) &&
							(_dataSource[i].Low <= _dataSource[i - 1].Low) &&
							(_dataSource[i - 1].Open <= _dataSource[i - 1].Close))	// Except red sessions
					{
						_values[i - 1] = 0;
						if (_dataSource[i - 2].High <= _dataSource[i].High)
							_values[i - 2] = 0;
						else
							_values[i] = 0;
					}
				}
			}
		}
/*
		private void ComposeTrend4()
		{
			// If an extreme low has higher high than the adjacent extreme highs
			for (int i = FindExtremePointBackward(7); i < _values.Count; )
			{
				int x1 = FindNextExtremePoint(i);
				if (x1 < 0)
					break;

				int x2 = FindNextExtremePoint(x1 + 1);
				if (x2 < 0)
					break;

				int x3 = FindNextExtremePoint(x2 + 1);
				if (x3 < 0)
					break;

				int x4 = FindNextExtremePoint(x3 + 1);
				if (x4 < 0)
					break;

				int x5 = FindNextExtremePoint(x4 + 1);
				if (x5 < 0)
					break;

				// extremes 1, 3, 5 are on the same side, extremes 2,4 are on the other side
				if ((_values[x1] == _values[x3]) && (_values[x3] == _values[x5]) && (_values[x2] == _values[x4]) && (_values[x2] != _values[x3]))
				{
					if ((_values[x3] == -1) && (High(x2) < High(x3)) && (High(x4) < High(x3)) && ((Low(x1) < Low(x3)) || (Low(x5) < Low(x3))))
					{
						_values[x3] = _values[x2];
						_values[x2] = _values[x4] = 0;
					}
					else if ((_values[x3] == 1) && (Low(x2) > Low(x3)) && (Low(x4) > Low(x3)) && ((High(x1) < High(x3)) || (High(x5) < High(x3))))
					{
						_values[x3] = _values[x2];
						_values[x2] = _values[x4] = 0;
					}
				}
				else
				{
					System.Diagnostics.Debug.Assert(false, String.Format("x1 = {0}, x2 = {1}, x3 = {2}, x4 = {3}, x5 = {4}, ", x1, x2, x3, x4, x5));
				}

				i = x1 + 1;
			}
		}
*/
/*
		private void ComposeTrend5()
		{
			// Pick the most extreme sessions
			for (int i = FindExtremePointBackward(5); i < _values.Count; )
			{
				int x1 = FindNextExtremePoint(i);
				if (x1 < 0)
					break;

				int x2 = FindNextExtremePoint(x1 + 1);
				if (x2 < 0)
					break;

				int x3 = FindNextExtremePoint(x2 + 1);
				if (x3 < 0)
					break;

				int newExtreme = x2;
				bool isTop = (_values[x2] == 1);
				for (int j = x1 + 1; j < x3; j++)
				{
					if (isTop)
					{
						if (High(j) > High(newExtreme))
							newExtreme = j;
					}
					else
					{
						if (Low(j) < Low(newExtreme))
							newExtreme = j;
					}
				}

				if (newExtreme != x2)
				{
					_values[newExtreme] = _values[x2];
					_values[x2] = 0;
				}

				i = newExtreme;
			}
		}
*/
		private void CreateExtremesList()
		{
			_extremePoints = new List<ExtremePoint>();

			int lastRank = 0;
			for (int i = 0; i < _values.Count; i++)
			{
				if (_values[i] != 0)
				{
					AddNewExtremePoint(i);
					lastRank = _values[i];
				}
			}
		}


		#region Helper Methods

		private void AddNewExtremePoint(int index)
		{
			ExtremePoint extremePoint;
			if (_values[index] > 0)
				extremePoint = new ExtremePoint(index, _dataSource[index].High, ExtremePointType.Max);
			else
				extremePoint = new ExtremePoint(index, _dataSource[index].Low, ExtremePointType.Min);

			_extremePoints.Add(extremePoint);
		}

		private int FindNextExtremePoint(int position)
		{
			if (position < 0)
				return -1;

			for (int i = position; i < _values.Count; i++)
			{
				if (_values[i] != 0)
					return i;
			}

			return -1;
		}

		private int FindPreviousExtremePoint(int position)
		{
			if (position > _values.Count - 1)
				throw new ArgumentOutOfRangeException();

			for (int i = position; i >= 0 ; i--)
			{
				if (_values[i] != 0)
					return i;
			}

			return -1;
		}

		/// <summary>
		/// Finds the "N - count" extreme point
		/// </summary>
		/// <param name="count">Number of extremes to go back</param>
		/// <returns></returns>
		private int FindExtremePointBackward(int count)
		{
			for (int i = _values.Count - 1; i >= 0; i--)
			{
				if (_values[i] != 0)
				{
					count--;
					if (count <= 0)
						return i;
				}
			}

			return 0;
		}


		private bool IsHigherHigh(int i1, int i2)
		{
			return (_dataSource[i1].High < _dataSource[i2].High);
		}

		private bool IsLowerLow(int i1, int i2)
		{
			return (_dataSource[i1].Low > _dataSource[i2].Low);
		}

		#endregion

		#region Trading Range
/*
		private List<TradingRange> _tradingRanges;

		public List<TradingRange> FindTradingRanges()
		{
			_tradingRanges = new List<TradingRange>();

			double coeff = 0.1;

			for (int i = 0; i < _values.Count; i++)
			{
				int x1 = FindNextExtremePoint(i);
				if (x1 < 0)
					break;

				int x2 = FindNextExtremePoint(x1 + 1);
				if (x2 < x1)
					break;

				int x3 = FindNextExtremePoint(x2 + 1);
				if (x3 < x2)
					break;

				int x4 = FindNextExtremePoint(x3 + 1);
				if (x4 < x3)
					break;

				double low = 0, high = 0;
				if (_values[x1] == -1)
				{
					if ((Math.Abs(Low(x1) - Low(x3)) < coeff * Math.Max(Low(x1), Low(x3))) && (Math.Abs(High(x2) - High(x4)) < coeff * Math.Max(High(x2), High(x4))))
					{
						low = Math.Min(Low(x1), Low(x3));
						high = Math.Max(High(x2), High(x4));
					}
				}
				else
				{
					if ((Math.Abs(High(x1) - High(x3)) < coeff * Math.Max(High(x1), High(x3))) && (Math.Abs(Low(x2) - Low(x4)) < coeff * Math.Max(Low(x2), Low(x4))))
					{
						low = Math.Min(Low(x2), Low(x4));
						high = Math.Max(High(x1), High(x3));
					}
				}

				if((low > 0) && (high > 0))
				{
					int start = x4;
					while (true)
					{
						int x5 = FindNextExtremePoint(start + 1);
						if (x5 < start)
							break;

						int x6 = FindNextExtremePoint(x5 + 1);
						if (x6 < x5)
							break;

						//if ((Math.Max(Open(x5), Close(x5)) <= high) && (Math.Min(Open(x5), Close(x5)) >= low) && (Math.Max(Open(x6), Close(x6)) <= high) && (Math.Min(Open(x6), Close(x6)) >= low))
						if ((High(x5) <= high) && (Low(x5) >= low) && (High(x6) <= high) && (Low(x6) >= low))
						{
							start = x6;
						}
						else
						{
							break;
						}
					}

					if (start > x4)
					{
						TradingRange tr = new TradingRange(x1, start, low, high);
						_tradingRanges.Add(tr);

						i = start;
					}
				}
			}

			return _tradingRanges;
		}

		public List<TradingRange> FindTradingRanges2()
		{
			_tradingRanges = new List<TradingRange>();
			double coeff2 = 0.5;

			for (int i = 0; i < _values.Count; i++)
			{
				double coeff = 0.5;

				int x1 = FindNextExtremePoint(i);
				if (x1 < 0)
					break;

				int x2 = FindNextExtremePoint(x1 + 1);
				if (x2 < x1)
					break;

				int start = x1, stop = x2;
				double low = 0, high = 0;
				int hitHighBand = 0, hitLowBand = 0;

				for (int direction = 0; direction < 2; direction++)
				{
					if (_values[x1] == -1)
					{
						low = Low(x1);
						high = High(x2);
						coeff *= (high - low);

						int counter = 0;
						while (counter < 20)
						{
							int x5, x6;
							if (direction == 0)
							{
								x5 = FindNextExtremePoint(stop + 1);
								if (x5 < 0)
									break;

								x6 = FindNextExtremePoint(x5 + 1);
								if (x6 < 0)
									break;
							}
							else if (direction == 1)
							{
								x6 = FindPreviousExtremePoint(start - 1);
								if (x6 < 0)
									break;

								x5 = FindPreviousExtremePoint(x6 - 1);
								if (x5 < 0)
									break;
							}
							else
							{
								throw new InvalidOperationException();
							}

							//TODO: check if Open/Close are between the bounds
							if ((low <= Low(x5)) && (High(x6) <= high))
							{
								if ((Math.Abs((low - Low(x5)) / low * 100) <= coeff2) || (Math.Abs((high - High(x6)) / high * 100) <= coeff2))
								{
									counter = 0;
									if (direction == 0)
										stop = x6;
									else if (direction == 1)
										start = x5;

									if (Math.Abs((low - Low(x5)) / low * 100) <= coeff2)
										hitLowBand++;

									if (Math.Abs((high - High(x6)) / high * 100) <= coeff2)
										hitHighBand++;
								}
							}
							else
							{
								break;
							}

							counter++;
						}
					}
					else
					{
						low = Low(x2);
						high = High(x1);

						coeff *= (high - low);

						int counter = 0;
						while (counter < 20)
						{
							int x5, x6;
							if (direction == 0)
							{
								x5 = FindNextExtremePoint(stop + 1);
								if (x5 < 0)
									break;

								x6 = FindNextExtremePoint(x5 + 1);
								if (x6 < 0)
									break;
							}
							else if (direction == 1)
							{
								x6 = FindPreviousExtremePoint(start - 1);
								if (x6 < 0)
									break;

								x5 = FindPreviousExtremePoint(x6 - 1);
								if (x5 < 0)
									break;
							}
							else
							{
								throw new InvalidOperationException();
							}

							//TODO: check if Open/Close are between the bounds
							if ((high >= High(x5)) && (Low(x6) >= low))
							{
								if ((Math.Abs((low - Low(x6)) / low * 100) <= coeff2) || (Math.Abs((high - High(x5)) / high * 100) <= coeff2))
								{
									counter = 0;
									if (direction == 0)
										stop = x6;
									else if (direction == 1)
										start = x5;

									if (Math.Abs((low - Low(x6)) / low * 100) <= coeff2)
										hitLowBand++;

									if (Math.Abs((high - High(x5)) / high * 100) <= coeff2)
										hitHighBand++;
								}
							}
							else
							{
								break;
							}

							counter++;
						}
					}
				}

				if ((stop > x2) && (hitLowBand >=2) && (hitHighBand >=2) && (hitLowBand + hitHighBand >= 5))
				{
					TradingRange tr = new TradingRange(start, stop, low, high);
					_tradingRanges.Add(tr);

					i = x2;
				}
			}

			return _tradingRanges;
		}

		public List<TradingRange> FindTradingRanges3()
		{
			_tradingRanges = new List<TradingRange>();

			double coeff = 0.01;

			for (int i = _values.Count - 1; i > 0; i--)
			{
				int x1 = FindPreviousExtremePoint(i);
				if (x1 < 0)
					break;

				int counter = 0;
				int start = x1, stop = start;
				int isOnLow = 0, isOnHigh = 0, isInside = 0, isOutside = 0;

				while (counter < 10)
				{
					int x2 = FindPreviousExtremePoint(start - 1);
					if (x2 < 0)
						break;

					if (_values[x1] == _values[x2])
					{
						if (_values[x1] == 1)
						{
							if ((Math.Abs(High(x1) - High(x2)) <= coeff * High(x1)) || (Math.Abs(High(x1) - Math.Max(Close(x2), Open(x2))) <= coeff * High(x1)))
							{
								isOnHigh++;
								counter = 0;
								stop = x2;
							}
							else if (High(x1) > High(x2))
							{
								isInside++;
							}
							else
							{
								isOutside++;
								counter++;
							}
						}
						else
						{
							if ((Math.Abs(Low(x1) - Low(x2)) <= coeff * Low(x1)) || (Math.Abs(Low(x1) - Math.Min(Close(x2), Open(x2))) <= coeff * Low(x1)))
							{
								isOnLow++;
								counter = 0;
								stop = x2;
							}
							else if (Low(x1) < Low(x2))
							{
								isInside++;
							}
							else
							{
								isOutside++;
								counter++;
							}
						}
					}

					start = x2;

					counter++;
				}


				if (((isOnLow >= 2) || (isOnHigh >= 2)) && (isInside >= isOutside))
				{
					TradingRange tr;
					if(isOnLow >= 2)
						tr = new TradingRange(stop, x1, Low(stop), Low(x1));
					else
						tr = new TradingRange(stop, x1, High(stop), High(x1));

					_tradingRanges.Add(tr);
				}

				i = x1;
			}

			return _tradingRanges;
		}

		public List<TradingRange> FindTradingRanges4()
		{
			if(_tradingRanges == null)
				_tradingRanges = new List<TradingRange>();

			int start = FindPreviousExtremePoint(_values.Count - 1);
			if (start > 0)
			{
				int next = -1;
				for (int i = start; i > 0; i = FindPreviousExtremePoint(i - 1))
				{
					double sum = 0.0;
					double min = double.MaxValue, max = double.MinValue;

					int x1 = -1, x2 = i;
					double lastMin = 0, lastMax = 0;
					int counter = 0;
					do
					{
						x1 = next;
						lastMin = min;
						lastMax = max;

						next = FindPreviousExtremePoint((next > 0 ? next : i) - 1);
						if (next < 0)
							break;

						counter++;

						if (_values[i] == 1)
						{
							sum += High(i) - Low(next);
							min = Math.Min(min, Low(next));
							max = Math.Max(max, High(i));
						}
						else
						{
							sum += Low(i) - High(next);
							min = Math.Min(min, Low(i));
							max = Math.Max(max, High(next));
						}
					} while (Math.Abs(sum) <= 1.25 * Math.Abs(max - min));

					if ((counter > 5) && (x1 >= 0) && (x2 >= 40))
					{
						TradingRange tr;
						tr = new TradingRange(x1, x2, lastMin, lastMax);

						_tradingRanges.Add(tr);
					}
				}
			}

			return _tradingRanges;
		}

		public List<TradingRange> FindTradingRanges5()
		{
			if(_tradingRanges == null)
				_tradingRanges = new List<TradingRange>();

			for (int i = FindPreviousExtremePoint(_values.Count - 1); i >= 0; i = FindPreviousExtremePoint(i - 1))
			{
				int next = i;
				int x1 = -1, x2 = i;
				int counter = 0;

				double sum = 0.0, sumAbs = 0;
				double low = Low(next), high = High(next);
				double min = Low(next), max = High(next);

				do
				{
					x1 = next;

					low += Low(x1);
					high += High(x1);
					min = Math.Min(min, Low(x1));
					max = Math.Max(max, High(x1));

					next = FindPreviousExtremePoint(next - 1);
					if (next < 0)
						break;

					counter++;

					if (_values[x1] == 1)
					{
						sum += High(x1) - Low(next);
						sumAbs += Math.Abs(High(x1) - Low(next));
					}
					else
					{
						sum += Low(x1) - High(next);
						sumAbs += Math.Abs(Low(x1) - High(next));
					}
				} while (Math.Abs(sum) <= ((max + (high + High(next)) / counter) / 2 - ((min + (low + Low(next)) / counter) / 2)));

				if ((counter > 5) && (x1 < x2))
				{
					TradingRange tr;
					tr = new TradingRange(x1, x2, min, max);

					_tradingRanges.Add(tr);
				}

				//break;
			}

			return _tradingRanges;
		}

		public List<TradingRange> FindTradingRanges6()
		{
			_tradingRanges = new List<TradingRange>();

			for (int i = 0; i < _values.Count; i = FindNextExtremePoint(i + 1))
			{
				int x1 = FindNextExtremePoint(i);
				if (x1 < 0)
					break;

				double min = double.MaxValue, max = double.MinValue, lastMin = 0, lastMax = 0, tmpLastMin = double.MaxValue, tmpLastMax = double.MinValue;

				int x2 = x1, x3 = x1, counter = 0;
				while ((x2 = FindNextExtremePoint(x2 + 1)) > 0)
				{
					if((min != double.MaxValue) && (tmpLastMin == double.MaxValue))
						tmpLastMin = min;
					if ((max != double.MinValue) && (tmpLastMax == double.MinValue))
						tmpLastMax = max;

					lastMin = tmpLastMin;
					lastMax = tmpLastMax;
					tmpLastMin = min;
					tmpLastMax = max;

					if (_values[x1] == 1)
					{
						if (_values[x2] == -1)
						{
							if (lastMax >= lastMin)
							{
								if (lastMax <= Low(x2))
									break;
								else
									counter++;
							}
							min = Math.Min(min, Low(x2));
						}
						else
						{
							max = Math.Max(max, High(x2));
						}
					}
					else
					{
						if (_values[x2] == 1)
						{
							if (lastMin <= lastMax)
							{
								if (lastMin >= High(x2))
									break;
								else
									counter++;
							}
							max = Math.Max(max, High(x2));
						}
						else
						{
							min = Math.Min(min, Low(x2));
						}
					}

					x3 = x2;
				}

				if ((counter > 3) && (x1 < x3))
				{
					TradingRange tr;
					tr = new TradingRange(x1, FindPreviousExtremePoint(x3 - 1), lastMin, lastMax);

					_tradingRanges.Add(tr);

					i = x3;
				}

			}

			return _tradingRanges;
		}

		public List<TradingRange> FindTradingRanges7()
		{
			//if (_tradingRanges != null)
			//	return _tradingRanges;

			_tradingRanges = new List<TradingRange>();

			bool success = false;
			int first = -1, last = -1, counter = 0;
			double low = 0, high = 0;
			double max = double.MinValue, sum = 0.0;

			for (int i = 0; (i >= 0) && (i < _values.Count); i = FindNextExtremePoint(i + 1))
			{
				sum = 0.0;

				int x1 = i;

				int x2 = FindNextExtremePoint(x1 + 1);
				if (x2 < 0)
					break;

				int x3 = FindNextExtremePoint(x2 + 1);
				if (x3 < 0)
					break;

				int x4 = FindNextExtremePoint(x3 + 1);
				if (x4 < 0)
					break;

				int x5 = FindNextExtremePoint(x4 + 1);
				if (x5 < 0)
					break;

				int x6 = FindNextExtremePoint(x5 + 1);
				if (x6 < 0)
					break;

				if (_values[x1] == 1)
				{
					max = Math.Max(max, High(x1) - Low(x2));
					max = Math.Max(max, High(x3) - Low(x2));
					max = Math.Max(max, High(x3) - Low(x4));
					max = Math.Max(max, High(x5) - Low(x4));
					max = Math.Max(max, High(x5) - Low(x6));

					sum += High(x1) - Low(x6);
				}
				else
				{
					max = Math.Max(max, High(x2) - Low(x1));
					max = Math.Max(max, High(x2) - Low(x3));
					max = Math.Max(max, High(x4) - Low(x3));
					max = Math.Max(max, High(x4) - Low(x5));
					max = Math.Max(max, High(x6) - Low(x5));

					sum += High(x6) - Low(x1);
				}

				if (sum <= max)
				{
					if (!success)
					{
						success = true;
						first = x1;
						if (_values[first] == 1)
						{
							low = Math.Min(Low(x2), Math.Min(Low(x4), Low(x6)));
							high = Math.Max(High(x1), Math.Max(High(x3), High(x5)));
						}
						else
						{
							low = Math.Min(Low(x1), Math.Min(Low(x3), Low(x5)));
							high = Math.Max(High(x2), Math.Max(High(x4), High(x6)));
						}
					}
					else
					{
						if (_values[first] == 1)
						{
							low = Math.Min(low, Math.Min(Low(x2), Math.Min(Low(x4), Low(x6))));
							high = Math.Max(high, Math.Max(High(x1), Math.Max(High(x3), High(x5))));
						}
						else
						{
							low = Math.Min(low, Math.Min(Low(x1), Math.Min(Low(x3), Low(x5))));
							high = Math.Max(high, Math.Max(High(x2), Math.Max(High(x4), High(x6))));
						}
					}

					last = x6;
					counter++;
				}
				else
				{
					if (success && (counter > 3) && (_values[first] != _values[last]))
					{
						TradingRange tr;

						tr = new TradingRange(first, last, low, high);

						_tradingRanges.Add(tr);
					}

					success = false;
					first = -1;
					last = -1;
					low = 0;
					high = 0;
					sum = 0;
					max = double.MinValue;
					counter = 0;
				}
			}

			return _tradingRanges;
		}

		private int _lastTradingRange = 0;
		public List<TradingRange> FindTradingRanges8()
		{
			//if(_tradingRanges == null)
				_tradingRanges = new List<TradingRange>();

			double coeff = 0.15;

			for (int i = FindNextExtremePoint(_lastTradingRange); (i > -1) && (i < _values.Count); i = FindNextExtremePoint(i + 1))
			{
				int trend1Start = i, trend1End = -1, trend2End = -1, trend3End = -1;

				// We have a strong trend
				if(FindStrongTrend(trend1Start, out trend1End) && (trend1End > trend1Start) &&
					 FindStrongTrend(trend1End, out trend2End) && (trend2End > trend1End) &&
					 FindStrongTrend(trend2End, out trend3End) && (trend3End > trend2End))
				{
					double min = 0, max = 0, trendHeight = 0;
					int legs = 0;

					if (_values[trend1Start] == 1)
					{
						trendHeight = Math.Max(High(trend1Start), High(trend2End)) - Math.Min(Low(trend1End), Low(trend3End));

						if ((Math.Abs(High(trend1Start) - High(trend2End)) <= coeff * trendHeight) &&
								(Math.Abs(Low(trend1End) - Low(trend3End)) <= coeff * trendHeight))
						{
							max = Math.Max(High(trend1Start), High(trend2End));
							min = Math.Min(Low(trend1End), Low(trend3End));

							legs = 3;
						}
					}
					else
					{
						trendHeight = Math.Max(High(trend1End), High(trend3End)) - Math.Min(Low(trend1Start), Low(trend2End));

						if ((Math.Abs(Low(trend1Start) - Low(trend2End)) <= coeff * trendHeight) &&
								(Math.Abs(High(trend1End) - High(trend3End)) <= coeff * trendHeight))
						{
							max = Math.Max(High(trend1End), High(trend3End));
							min = Math.Min(Low(trend1Start), Low(trend2End));

							legs = 3;
						}
					}

					double min2 = min, max2 = max;
					int counter = 0;
					int rangeEnd = trend3End;
					while ((legs >= 3) && (rangeEnd = FindNextExtremePoint(rangeEnd + 1)) != -1)
					{
						if (_values[rangeEnd] == 1)
						{
							if ((High(rangeEnd) <= min) || (Math.Max(Open(rangeEnd), Close(rangeEnd)) <= min))
								counter++;

							else if (High(rangeEnd) > max)
								counter++;
							else
							{
								counter = 0;
								legs++;
							}
						}
						else 
						{
							if ((Low(rangeEnd) >= max) || (Math.Min(Open(rangeEnd), Close(rangeEnd)) >= max))
								counter++;

							else if (Low(rangeEnd) < min)
								counter++;
							else
							{
								counter = 0;
								legs++;
							}
						}

						if (counter >= 2)
							break;

						if (counter == 0)
						{
							min2 = Math.Min(min2, Low(rangeEnd));
							max2 = Math.Max(max2, High(rangeEnd));

							trend3End = rangeEnd;
						}
					}

					min = min2;
					max = max2;

					if (((legs >= 4) || (counter < 2)) && (trend1Start > 0) && (trend3End > trend1Start) && (min > 0))
					{
						TradingRange tr;

						tr = new TradingRange(trend1Start, trend3End, min, max);

						_tradingRanges.Add(tr);

						i = trend3End - 1;
						//_lastTradingRange = trend1Start;
					}
					else
					{
						i = FindPreviousExtremePoint(trend1End) - 1;
					}
				}
			}

			return _tradingRanges;
		}

		private bool FindStrongTrend(int start, out int end)
		{
			end = FindNextExtremePoint(start + 1);

			int x1 = start, first = start, last = -1;

			do
			{
				int x2 = FindNextExtremePoint(x1 + 1);
				if (x2 < x1)
					break;

				int x3 = FindNextExtremePoint(x2 + 1);
				if (x3 < x2)
					break;

				int x4 = FindNextExtremePoint(x3 + 1);
				if (x4 < x3)
					break;

				System.Diagnostics.Debug.Assert((Math.Sign(_values[x1]) == Math.Sign(_values[x3])) && (Math.Sign(_values[x2]) == Math.Sign(_values[x4])));

				if (_values[x1] > 0)
				{
					if (!((High(x1) > High(x3)) && (Low(x2) > Low(x4))))
					{
						break;
					}
				}
				else if (_values[x1] < 0)
				{
					if (!((Low(x1) < Low(x3)) && (High(x2) < High(x4))))
					{
						break;
					}
				}

				x1 = x3;
				last = x4;
			} while (true);

			if (last > first)
			{
				end = last;
			}

			return true;
		}

		private void FindStrongTrends()
		{
			for (int i = 0; i < _values.Count; i++)
			{
				if (_values[i] == 0)
					continue;

				int x1 = i;

				int x2 = FindNextExtremePoint(x1 + 1);
				if (x2 < x1)
					break;

				int x3 = FindNextExtremePoint(x2 + 1);
				if (x3 < x2)
					break;

				int x4 = FindNextExtremePoint(x3 + 1);
				if (x4 < x3)
					break;

				if ((Math.Sign(_values[x1]) == Math.Sign(_values[x3])) && (Math.Sign(_values[x2]) == Math.Sign(_values[x4])))
				{
					if (_values[x1] > 0)
					{
						if ((High(x1) > High(x3)) && (Low(x2) > Low(x4)))
						{
							_values[x2] = _values[x3] = 0;
						}
					}
					else if (_values[x1] < 0)
					{
						if ((Low(x1) < Low(x3)) && (High(x2) < High(x4)))
						{
							_values[x2] = _values[x3] = 0;
						}
					}
				}
				else
				{
					System.Diagnostics.Debug.Assert(false);
				}

				// Search from the same pivot
				if ((_values[x2] == 0) && (_values[x3] == 0))
					i--;
			}
		}
*/
		#endregion

	}
}
