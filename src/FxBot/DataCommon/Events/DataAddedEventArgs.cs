using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCommon
{
	public class DataAddedEventArgs : EventArgs
	{
		public IList<IDataItem> NewItems { get; set; }

		public DataAddedEventArgs(IList<IDataItem> newItems)
		{
			NewItems = newItems;
		}
	}

	public delegate void DataAddedEventHandler(object sender, DataAddedEventArgs e);

}
