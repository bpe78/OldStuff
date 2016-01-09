using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;

namespace DataReceiverProxy
{
	public class ReceiverProxy
	{
		#region Members & Properties

		private IDataProvider _dataProvider;
		private IDataController _dataController;
		private bool _cacheDataLocally;
		List<IDataItem> _cachedItems;

		public bool ForceSequentialAccess { get; set; }

		#endregion

		public ReceiverProxy(IDataProvider dataProvider, IDataController dataController)
		{
			System.Diagnostics.Debug.Assert(dataProvider != null);
			
			_dataProvider = dataProvider;
			if (_dataProvider != null)
			{
				_dataProvider.DataReceived += OnDataReceived;
			}

			System.Diagnostics.Debug.Assert(dataController != null);
			_dataController = dataController;
			if (_dataController != null)
			{
				_dataController.ProcessingCompleted += ProcessingCompleted;
			}

			_cacheDataLocally = false;
			_cachedItems = new List<IDataItem>();

			ForceSequentialAccess = true;
		}

		private void OnDataReceived(object sender, DataReceivedEventArgs e)
		{
			lock (this)
			{
				if (e.Item != null)
				{
					_cachedItems.Add(e.Item);
				}
				else if (e.Items != null)
				{
					_cachedItems.AddRange(e.Items);
				}
				else
					throw new NotImplementedException();

				if (!_cacheDataLocally)
				{
					ForwardData();
				}
			}
		}

		private void ForwardData()
		{
			lock (this)
			{
				if (_cachedItems.Count == 0)
					return;

				_cacheDataLocally = true;

				if (ForceSequentialAccess || (_cachedItems.Count == 1))
				{
					IDataItem item = _cachedItems[0];
					_cachedItems.RemoveAt(0);
					//Console.WriteLine("{1}:{2} - ForwardData : {0}", item, DateTime.Now.Second, DateTime.Now.Millisecond);
					_dataController.AddData(item);
				}
				else
				{
					List<IDataItem> items = new List<IDataItem>(_cachedItems);

					_cachedItems.Clear();
					_dataController.AddData(items);
				}
			}
		}

		private void ProcessingCompleted(object sender, ProcessingCompletedEventArgs args)
		{
			lock (this)
			{
				_cacheDataLocally = false;

				if (_cachedItems.Count > 0)
					ForwardData();
			}
		}
	}
}
