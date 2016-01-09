using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;

namespace DataModel
{
	public class DataItem : IDataItem
	{
		#region Members & Properties

		public DateTime Date { get; protected set; }
		public double Open { get; protected set; }
		public double High { get; protected set; }
		public double Low { get; protected set; }
		public double Close { get; protected set; }
		public long Volume { get; protected set; }
		public long OpenInterest { get; protected set; }

		#endregion

		#region Contructors

		public DataItem(DateTime date, int open, int high, int low, int close)
			: this(date, open, high, low, close, 0)
		{ }

		public DataItem(DateTime date, double open, double high, double low, double close)
			: this(date, open, high, low, close, 0, 0)
		{ }


		public DataItem(DateTime date, int open, int high, int low, int close, long volume)
			: this(date, open, high, low, close, volume, 0)
		{ }

		public DataItem(DateTime date, double open, double high, double low, double close, long volume)
			: this(date, open, high, low, close, volume, 0)
		{ }

		public DataItem(DateTime date, double open, double high, double low, double close, long volume, long openInterest)
		{
			Date = date;
			Open = open;
			High = high;
			Low = low;
			Close = close;
			Volume = volume;
			OpenInterest = openInterest;
		}

		#endregion

		public override string ToString()
		{
			//string fmt = "000000";
			string fmt = "#.#####";
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("Date={0}, ", Date.ToString("yyyy/MM/dd HH:mm:ss"));
			sb.AppendFormat("Open={0}, ", Open.ToString(fmt));
			sb.AppendFormat("High={0}, ", High.ToString(fmt));
			sb.AppendFormat("Low={0}, ", Low.ToString(fmt));
			sb.AppendFormat("Close={0}, ", Close.ToString(fmt));
			sb.AppendFormat("Volume={0,12}, ", Volume);
			sb.AppendFormat("OpenInterest={0,12}", OpenInterest);

			return sb.ToString();
		}

	}
}
