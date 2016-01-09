using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;

namespace DataController
{
	public class TimeFrameDurations
	{
		public static int Duration(TimeFrame timeframe)
		{
			switch (timeframe)
			{
				case TimeFrame.M01 : return 1;
				case TimeFrame.M05 : return 5;
				case TimeFrame.M15 : return 15;
				case TimeFrame.M30 : return 30;
				case TimeFrame.H01 : return 60;
				case TimeFrame.D01 : return 24 * 60;
				case TimeFrame.Week: return 7 * 24 * 60;
				case TimeFrame.Month: return 30 * 24 * 60;
				case TimeFrame.NotSet:
				default :
					throw new ArgumentOutOfRangeException();
			}
		}

		public static DateTime Start(TimeFrame timeframe, DateTime firstSession)
		{
			DateTime start;
			switch (timeframe)
			{
				case TimeFrame.M01:
				case TimeFrame.M05:
				case TimeFrame.M15:
				case TimeFrame.M30:
				case TimeFrame.H01:
					{
						start = firstSession.AddMinutes(-(firstSession.Minute % Duration(timeframe)));
						start = start.AddSeconds(-start.Second);
						start = start.AddMilliseconds(-start.Millisecond);
					} break;

				case TimeFrame.D01:
					{
						start = firstSession.Subtract(firstSession.TimeOfDay);
					} break;

				case TimeFrame.Week:
					{
						start = firstSession.AddDays(- (6 + (int)firstSession.DayOfWeek) % 7);
						start = start.Subtract(start.TimeOfDay);
					} break;

				case TimeFrame.Month:
					{
						start = firstSession.AddDays(-firstSession.Day + 1);
						start = start.Subtract(start.TimeOfDay);
					} break;

				case TimeFrame.NotSet:
				default:
					throw new ArgumentOutOfRangeException();
			}

			return start;
		}

	}
}
