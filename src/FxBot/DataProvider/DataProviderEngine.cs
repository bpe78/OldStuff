using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataCommon;
using DataModel;

namespace DataProvider
{
	public class DataProviderEngine : IDataProvider
	{
		private List<IDataItem> _items;

		public DataProviderEngine()
		{
			_items = new List<IDataItem>();
			Load();
		}

		private bool _started = false, _paused = false;

		public void Start()
		{
			if (_started)
				throw new InvalidOperationException();

			_started = true;
			_paused = false;

			Random r = new Random(DateTime.Now.Millisecond);

			int timeout = 200;
			int sum = 0, count = 0;
			for (int i = 0; i < _items.Count; i++)
			{
				if (_paused)
				{
					while (_paused && _started)
						System.Threading.Thread.Sleep(10);
				}

				if (!_started)
					break;

				//count = Math.Min(r.Next(1, 5), _items.Count - i);
				count = 1;
				sum += count;

				if (count == 1)
				{
					IDataItem item = _items[i];

					OnDataReceived(item);
				}
				else
				{
					List<IDataItem> items = new List<IDataItem>(count);
					while (count > 0)
					{
						items.Add(_items[i++]);
						count--;
					}

					i--;

					OnDataReceived(items);
				}

				System.Threading.Thread.Sleep(timeout);
/*
				if (i + count > 100)
				{
					System.Diagnostics.Debug.Assert(false, "TODO: remove this !!!");
					count = i;
					break;
				}
*/
			}

			//Console.WriteLine("Sum = {0}, i = {1}", sum, count);
		}

		public void Pause()
		{
			if (_started)
			{
				_paused = !_paused;
			}
			else
			{
				_paused = false;
			}
		}

		public void Stop()
		{
			if (_started)
			{
				_started = false;
			}
		}

		private void Load()
		{
			this._items.Clear();
			this._items.AddRange(DataModel.DataModel.LoadDataCollection(1));
		}

		public event DataCommon.DataReceivedEventHandler DataReceived;

		private void OnDataReceived(IDataItem item)
		{
			if (DataReceived != null)
			{
				DataReceived(this, new DataCommon.DataReceivedEventArgs(item));
			}
		}

		private void OnDataReceived(IList<IDataItem> items)
		{
			if (DataReceived != null)
			{
				DataReceived(this, new DataCommon.DataReceivedEventArgs(items));
			}
		}
	}
}
