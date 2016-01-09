using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;

namespace TrendEngine
{
	public class TrendCalculator : TrendCalculatorBase
	{
		int[] rank = null;

		List<ExtremePoint> _extremePoints = null;

		public TrendCalculator(IList<IDataItem> data)
			: base(data)
		{
		}

		public List<ExtremePoint> CalculateTrends()
		{
			if (_extremePoints != null)
				return _extremePoints;

			CalculateExtremes();

			ComposeTrend();

			CreateExtremesList();

			return _extremePoints;
		}

		private void CalculateExtremes()
		{
			rank = new int[_data.Count];

			for (int i = 0; i < _data.Count; i++)
				rank[i] = 0;

			bool uptrend = false;

			// Calculate the first direction of the trend
			int next = 1;
			while ((next < _data.Count) && !IsHigherHigh(0, next) && !IsLowerLow(0, next))
				next++;
			if (next >= _data.Count)
				return;

			if (IsHigherHigh(0, next) && IsLowerLow(0, next))
			{
				System.Diagnostics.Debug.Assert(false);
				return;
			}

			if (IsHigherHigh(0, next))
			{
				rank[0] = -1;
				uptrend = true;
			}
			else if (IsLowerLow(0, next))
			{
				rank[0] = 1;
				uptrend = false;
			}
			else
			{
				// Should never appear
				System.Diagnostics.Debug.Assert(false);
			}

			// Calculate using a Higher High/Lower Low algorithm
			for (int i = next; i < _data.Count; i++)
			{
				next = i;

				if (uptrend)
				{
					while ((next < _data.Count - 1) && (High(next) <= High(next + 1)) && (Low(next) < Low(next + 1)))
						next++;
					if (next >= _data.Count)
						break;
					rank[next] = 1;
				}
				else
				{
					while ((next < _data.Count - 1) && (Low(next) >= Low(next + 1)) && (High(next) > High(next + 1)))
						next++;
					if (next >= _data.Count)
						break;
					rank[next] = -1;
				}

				uptrend = !uptrend;	// the trend must change
				i = next;
			}
		}

		private void ComposeTrend()
		{
			ComposeTrend1();

			ComposeTrend2();
			
			ComposeTrend3();

			ComposeTrend4();

			ComposeTrend5();
/*
			// Dump ranks to tracer
			for (int i = 0; i < rank.Length; i++)
				System.Diagnostics.Trace.Write(String.Format("{0}, ", rank[i]));
			System.Diagnostics.Trace.WriteLine(string.Empty);*/
		}

		private void ComposeTrend1()
		{
			// Move the extreme to the most extreme point, if different than the actual extreme
			for (int i = 0; i < _data.Count - 1; i++)
			{
				int x1 = FindNextExtremePoint(i);
				if (x1 < 0)
					break;

				if (rank[x1] == 1)
				{
					if ((x1 > 0) && (rank[x1 - 1] == 0) && (High(x1 - 1) > High(x1)))
					{
						rank[x1 - 1] = rank[x1];
						rank[x1] = 0;
					}
					else if ((x1 + 1 < _data.Count) && (rank[x1 + 1] == 0) && (High(x1) < High(x1 + 1)))
					{
						rank[x1 + 1] = rank[x1];
						rank[x1] = 0;
					}
				}
				else if (rank[x1] == -1)
				{
					if ((x1 > 0) && (rank[x1 - 1] == 0) && (Low(x1 - 1) < Low(x1)))
					{
						rank[x1 - 1] = rank[x1];
						rank[x1] = 0;
					}
					else if ((x1 + 1 < _data.Count) && (rank[x1 + 1] == 0) && (Low(x1) > Low(x1 + 1)))
					{
						rank[x1 + 1] = rank[x1];
						rank[x1] = 0;
					}
				}
				else
					// Should never appear
					System.Diagnostics.Debug.Assert(false);
			}
		}

		private void ComposeTrend2()
		{
			// If an extreme low has higher high than the adjacent extreme highs
			for (int i = 0; i < _data.Count; )
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
				if ((rank[x1] == rank[x3]) && (rank[x3] == rank[x5]) && (rank[x2] == rank[x4]) && (rank[x2] != rank[x3]))
				{
					if ((rank[x3] == -1) && IsHigherHigh(x2, x3) && IsHigherHigh(x4, x3) && !IsLowerLow(x1, x3) && !IsLowerLow(x5, x3))
					{
						rank[x3] = rank[x2];
						rank[x2] = rank[x4] = 0;
					}
					else if ((rank[x3] == 1) && IsLowerLow(x2, x3) && IsLowerLow(x4, x3) && !IsHigherHigh(x1, x3) && !IsHigherHigh(x5, x3))
					{
						rank[x3] = rank[x2];
						rank[x2] = rank[x4] = 0;
					}
				}
				else
					System.Diagnostics.Debug.Assert(false, String.Format("x1 = {0}, x2 = {1}, x3 = {2}, x4 = {3}, x5 = {4}, ", x1, x2, x3, x4, x5));

				i = x1 + 1;
			}
		}

		private void ComposeTrend3()
		{
			// Remove an extreme between 2 extremes if they are on consecutive sessions and no higher high/ lower low is produced
			for (int i = 2; i < _data.Count; i++)
			{
				if ((rank[i - 2] == -1) && (rank[i - 1] == 1) && (rank[i] == -1))
				{
					if ((Low(i - 2) < Low(i - 1)) && (Low(i) < Low(i - 1)) && (High(i - 2) >= High(i - 1)) && (High(i) >= High(i - 1)))
					{
						rank[i - 1] = 0;
						if (Low(i - 2) >= Low(i))
							rank[i - 2] = 0;
						else
							rank[i] = 0;
					}
				}
				else if ((rank[i - 2] == 1) && (rank[i - 1] == -1) && (rank[i] == 1))
				{
					if ((High(i - 2) > High(i - 1)) && (High(i) > High(i - 1)) && (Low(i - 2) <= Low(i - 1)) && (Low(i) <= Low(i - 1)))
					{
						rank[i - 1] = 0;
						if (High(i - 2) <= High(i))
							rank[i - 2] = 0;
						else
							rank[i] = 0;
					}
				}
			}
		}

		private void ComposeTrend4()
		{
			// If an extreme low has higher high than the adjacent extreme highs
			for (int i = 0; i < _data.Count; )
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
				if ((rank[x1] == rank[x3]) && (rank[x3] == rank[x5]) && (rank[x2] == rank[x4]) && (rank[x2] != rank[x3]))
				{
					if ((rank[x3] == -1) && (High(x2) < High(x3)) && (High(x4) < High(x3)) && ((Low(x1) < Low(x3)) || (Low(x5) < Low(x3))))
					{
						rank[x3] = rank[x2];
						rank[x2] = rank[x4] = 0;
					}
					else if ((rank[x3] == 1) && (Low(x2) > Low(x3)) && (Low(x4) > Low(x3)) && ((High(x1) < High(x3)) || (High(x5) < High(x3))))
					{
						rank[x3] = rank[x2];
						rank[x2] = rank[x4] = 0;
					}
				}
				else
					System.Diagnostics.Debug.Assert(false, String.Format("x1 = {0}, x2 = {1}, x3 = {2}, x4 = {3}, x5 = {4}, ", x1, x2, x3, x4, x5));

				i = x1 + 1;
			}
		}

		private void ComposeTrend5()
		{
			// Pick the most extreme sessions
			for (int i = 0; i < _data.Count; )
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
				bool isTop = (rank[x2] == 1);
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
					rank[newExtreme] = rank[x2];
					rank[x2] = 0;
				}

				i = newExtreme;
			}
		}

		private void CreateExtremesList()
		{
			_extremePoints = new List<ExtremePoint>();

			int lastRank = 0;
			for (int i = 0; i < _data.Count; i++)
			{
				if (rank[i] != 0)
				{
					AddNewExtremePoint(i);
					lastRank = rank[i];
				}
			}
		}


		#region Helper Methods

		private void AddNewExtremePoint(int index)
		{
			ExtremePoint extremePoint;
			if (rank[index] > 0)
				extremePoint = new ExtremePoint(index, High(index), ExtremePointType.Max);
			else
				extremePoint = new ExtremePoint(index, Low(index), ExtremePointType.Min);

			_extremePoints.Add(extremePoint);
		}

		private int FindNextExtremePoint(int position)
		{
			for (int i = position; i < _data.Count; i++)
			{
				if (rank[i] != 0)
					return i;
			}
			return -1;
		}

		#endregion
	}
}
