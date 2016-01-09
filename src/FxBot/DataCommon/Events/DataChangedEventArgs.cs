using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCommon
{
	public class DataChangedEventArgs : EventArgs
	{
		public IDataItem OldItem { get; private set; }
		public IDataItem NewItem { get; private set; }

		public DataChangedEventArgs(IDataItem oldItem, IDataItem newItem)
		{
			OldItem = oldItem;
			NewItem = newItem;
		}
	}

	public delegate void DataChangedEventHandler(object sender, DataChangedEventArgs e);
}
