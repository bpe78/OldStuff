using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCommon
{
	public class DataReceivedEventArgs : EventArgs
	{
		public IList<IDataItem> Items { get; private set; }
		public IDataItem Item { get; private set; }

		public DataReceivedEventArgs(IList<IDataItem> items)
		{
			Items = items;
			Item = null;
		}

		public DataReceivedEventArgs(IDataItem item)
		{
			Items = null;
			Item = item;
		}

	}

	public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);
}
