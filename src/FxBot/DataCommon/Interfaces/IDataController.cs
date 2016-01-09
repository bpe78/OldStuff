using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCommon
{
	public interface IDataController
	{
		void Start();
		void Pause();
		void Resume();
		void Stop();
		void AddData(IDataItem item);
		void AddData(IList<IDataItem> items);
		event ProcessingCompletedEventHandler ProcessingCompleted;
	}
}
