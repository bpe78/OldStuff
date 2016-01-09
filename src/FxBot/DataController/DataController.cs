using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;
using DataProvider;
using DataReceiverProxy;

namespace DataController
{
	public class DataController : IDataController
	{
		#region Members & Properties

		public Dictionary<TimeFrame, IDataView> DataViews { get; private set; }

		private DataProviderEngine _dataProvider;
		private ReceiverProxy _receiverProxy;

		#endregion

		#region Constructors

		public DataController()
		{
			// Connect to the data source
			_dataProvider = new DataProviderEngine();
			_receiverProxy = new ReceiverProxy(_dataProvider, this);

			// Create data views
			DataViews = new Dictionary<TimeFrame, IDataView>(Enum.GetValues(typeof(TimeFrame)).Length);

			foreach (TimeFrame frame in Enum.GetValues(typeof(TimeFrame)))
			{
				if (frame == TimeFrame.NotSet)
					continue;

				DataViews.Add(frame, new DataView(frame, this));
			}
		}

		#endregion

		#region IDataController Members

		public void Start()
		{
			_dataProvider.Start();
		}

		public void Pause()
		{
			_dataProvider.Pause();
		}

		public void Resume()
		{
			_dataProvider.Pause();
		}

		public void Stop()
		{
			_dataProvider.Stop();
		}

		public void AddData(IDataItem item)
		{
			foreach (KeyValuePair<TimeFrame, IDataView> pair in DataViews)
			{
				DataView dv = pair.Value as DataView;

				//Console.WriteLine("->Controller");
				//Console.WriteLine(item);
				//Console.WriteLine("<-Controller");
				//Console.WriteLine();

				dv.AddData(item);
			}

			ProcessingCompleted(this, new ProcessingCompletedEventArgs());
		}

		public void AddData(IList<IDataItem> items)
		{
			foreach (KeyValuePair<TimeFrame, IDataView> pair in DataViews)
			{
				DataView dv = pair.Value as DataView;
/*
				Console.WriteLine("->Controller");
				foreach (IDataItem item in items)
				{
					Console.WriteLine(item);
				}
				Console.WriteLine("<-Controller");
				Console.WriteLine();
*/
				dv.AddData(items);
			}

			ProcessingCompleted(this, new ProcessingCompletedEventArgs());
		}

		public event ProcessingCompletedEventHandler ProcessingCompleted;

		#endregion
	}
}
