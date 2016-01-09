using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;

namespace DataUtilities
{
	public class PriceUtilities
	{
		public static double Open(IDataItem data)
		{
			System.Diagnostics.Debug.Assert(data != null);
			if (data == null)
				throw new ArgumentNullException();

			return data.Open;
		}

		public static double High(IDataItem data)
		{
			System.Diagnostics.Debug.Assert(data != null);
			if (data == null)
				throw new ArgumentNullException();

			return data.High;
		}

		public static double Low(IDataItem data)
		{
			System.Diagnostics.Debug.Assert(data != null);
			if (data == null)
				throw new ArgumentNullException();

			return data.Low;
		}

		public static double Close(IDataItem data)
		{
			System.Diagnostics.Debug.Assert(data != null);
			if (data == null)
				throw new ArgumentNullException();

			return data.Close;
		}

		public static double MedianPrice(IDataItem data)
		{
			System.Diagnostics.Debug.Assert(data != null);
			if (data == null)
				throw new ArgumentNullException();

			System.Diagnostics.Debug.Assert(((data.High + data.Low) / 2) == (((double)data.High + data.Low) / 2.0));
			return (data.High + data.Low) / 2;
		}

		public static double TypicalPrice(IDataItem data)
		{
			System.Diagnostics.Debug.Assert(data != null);
			if (data == null)
				throw new ArgumentNullException();

			System.Diagnostics.Debug.Assert(((data.High + data.Low + data.Close) / 3) == (((double)data.High + data.Low + data.Close) / 3.0));
			return (data.High + data.Low + data.Close) / 3;
		}

		public static double WeightedPrice(IDataItem data)
		{
			System.Diagnostics.Debug.Assert(data != null);
			if (data == null)
				throw new ArgumentNullException();

			System.Diagnostics.Debug.Assert(((data.High + data.Low + data.Close + data.Close) / 4) == (((double)data.High + data.Low + data.Close + data.Close) / 4.0));
			return (data.High + data.Low + data.Close + data.Close) / 4;
		}

	}
}
