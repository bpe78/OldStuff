using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;
using DataModel;

namespace DataController
{
	public class DataView : IDataView
	{
		#region Members & Properties

		public TimeFrame Timeframe { get; private set; }

		private List<IDataItem> _dataItems;

		// Collection of moving average calculator parameters and their respective values
		//private Dictionary<MovingAverageDefinition, List<double>> _movingAverageItems;
		private Dictionary<int, List<double>> _movingAverageCollections;

		// Collection of gaps
		private List<IGapItem> _gapItems;

		// Collection of trends
		//private List<ITrendItem> _trendItems;
		private List<int> _trendItems;

		IDataController _controller;

		#endregion

		#region Constructors

		public DataView(TimeFrame timeframe, IDataController controller)
		{
			Timeframe = timeframe;
			_controller = controller;

			_dataItems = new List<IDataItem>();
			_movingAverageCollections = new Dictionary<int, List<double>>();

			//_trendItems = new List<ITrendItem>();
			_trendItems = new List<int>();
		}

		#endregion

		#region IDataView Members

		public IList<IDataItem> DataCollection
		{
			get
			{
				return _dataItems;
			}
		}
/*
		public IList<double> AddMovingAverageCollection(MovingAverageType type, int period, PriceFormula formula)
		{
			MovingAverageDefinition mad = new MovingAverageDefinition(type, period, formula);
			_movingAverageCollections.Add(mad, new List<double>());

			return GetMovingAverageCollection(mad, false);
		}
		public IList<double> GetMovingAverageCollection(MovingAverageType type, int period, PriceFormula formula, bool createNew)
		{
			MovingAverageDefinition filter = new MovingAverageDefinition(type, period, formula);

			return GetMovingAverageCollection(filter, createNew);
		}

		public IList<double> GetMovingAverageCollection(IMovingAverageDefinition filter, bool createNew)
		{
			foreach (MovingAverageDefinition mad in _movingAverageCollections.Keys)
			{
				if (mad.Equals(filter))
					return _movingAverageCollections[mad];
			}

			if (createNew)
				return AddMovingAverageCollection(filter.MovingAverageType, filter.Period, filter.Formula);

			return null;
		}
*/
		public int AddMovingAverageCollection()
		{
			int newId = _movingAverageCollections.Count;
			_movingAverageCollections.Add(newId, new List<double>());

			return newId;
		}

		public IList<double> GetMovingAverageCollection(int id)
		{
			if (_movingAverageCollections.ContainsKey(id))
				return _movingAverageCollections[id];
			else
				return null;
		}



		public IList<IGapItem> AddGapCollection()
		{
			_gapItems = new List<IGapItem>();

			return _gapItems;
		}

		public IList<IGapItem> GetGapCollection(bool createNew)
		{
			if ((_gapItems == null) && createNew)
				return AddGapCollection();

			return _gapItems;
		}

		public IList<int> AddTrendCollection()
		{
			_trendItems = new List<int>();

			return _trendItems;
		}

		public IList<int> GetTrendCollection(bool createNew)
		{
			if ((_trendItems == null) && createNew)
				return AddTrendCollection();

			return _trendItems;
		}

		public IList<double> AddIndicatorCollection(IndicatorType type, int period)
		{
			throw new NotImplementedException();
		}


		public event DataAddedEventHandler DataAdded;

		public event DataChangedEventHandler DataChanged;

		public void ProcessingCompleted(object sender, ProcessingCompletedEventArgs args)
		{
		}

		private void OnDataAdded(IList<IDataItem> items)
		{
			// Update data collection
			_dataItems.AddRange(items);

			// Update moving average data
			foreach (IList<double> ma in _movingAverageCollections.Values)
			{
				for (int i = 0; i < items.Count; i++)
					ma.Add(0);
			}

			
			// Update trend data
			for (int i = 0; i < items.Count; i++)
				_trendItems.Add(0);


/*
			Console.WriteLine("->OnDataAdded (TimeFrame = {0}, Item count = ({1})", Timeframe, items.Count);

			foreach (IDataItem item in items)
			{
				Console.WriteLine("D = {0}, O = {1}, H = {2}, L = {3}, C = {4}, V = {5}", TimeFrameDurations.Start(Timeframe, item.Date), item.Open, item.High, item.Low, item.Close, item.Volume);
			}
			Console.WriteLine("<-OnDataAdded (TimeFrame = {0}, Item count = ({1})", Timeframe, items.Count);
			Console.WriteLine();
*/
			if (DataAdded != null)
			{
				DataAdded(this, new DataAddedEventArgs(items));
			}
		}

		private void OnDataChanged(IDataItem oldItem, IDataItem newItem)
		{
/*
			Console.WriteLine("->OnDataChanged");

			Console.WriteLine("OldItem = {0}", oldItem);
			Console.WriteLine("NewItem = {0}", newItem);

			Console.WriteLine("<-OnDataChanged");
*/
			if (DataChanged != null)
			{
				DataChanged(this, new DataChangedEventArgs(oldItem, newItem));
			}
		}

		#endregion

		public void AddData(IDataItem item)
		{
			if ((_dataItems.Count > 0) &&
				TimeFrameDurations.Start(Timeframe, _dataItems[_dataItems.Count - 1].Date) == TimeFrameDurations.Start(Timeframe, item.Date))
			{
				IDataItem oldItem = _dataItems[_dataItems.Count - 1];
				IDataItem newItem = new DataItem(TimeFrameDurations.Start(Timeframe, item.Date), oldItem.Open, Math.Max(oldItem.High, item.High), Math.Min(oldItem.Low, item.Low), item.Close);

				_dataItems[_dataItems.Count - 1] = newItem;
				OnDataChanged(oldItem, newItem);
			}
			else
			{
				List<IDataItem> items = new List<IDataItem>();
				items.Add(item);

				OnDataAdded(items);
			}
		}

		/// <summary>
		/// Adds all items in the list to the internal data items list.
		/// If the first items are continuation of the previous added timeframe, then a change notification is raised for the changed items.
		/// Then all remaining items are added and only one notification is raised for all of them.
		/// </summary>
		/// <param name="items"></param>
		public void AddData(IList<IDataItem> items)
		{
			if((items == null) || (items.Count == 0))
				throw new ArgumentException();

			List<IDataItem> newItems = null;
			IDataItem oldItem = null;

			int index;
			DateTime date;
			double open, high, low, close;
			long volume;

			if ((_dataItems.Count > 0) &&
					(TimeFrameDurations.Start(Timeframe, _dataItems[_dataItems.Count - 1].Date) == TimeFrameDurations.Start(Timeframe, items[0].Date)))
			{
				oldItem = _dataItems[_dataItems.Count - 1];

				//date = oldItem.Date;
				date = TimeFrameDurations.Start(Timeframe, _dataItems[_dataItems.Count - 1].Date);
				open = oldItem.Open;
				high = oldItem.High;
				low = oldItem.Low;
				close = oldItem.Close;
				volume = oldItem.Volume;

				index = 0;
				while ((index < items.Count) && TimeFrameDurations.Start(Timeframe, date) == TimeFrameDurations.Start(Timeframe, items[index].Date))
				{
					//date = items[index].Date;
					high = Math.Max(high, items[index].High);
					low = Math.Min(low, items[index].Low);
					close = items[index].Close;
					volume += items[index].Volume;

					index++;
				}

				IDataItem newItem = new DataItem(date, open, high, low, close, volume);
				_dataItems[_dataItems.Count - 1] = newItem;

				OnDataChanged(oldItem, newItem);
			}
			else
				index = 0;

			if (index < items.Count)
				newItems = new List<IDataItem>();

			while(index < items.Count)
			{
				//date = items[index].Date;
				date = TimeFrameDurations.Start(Timeframe, items[index].Date);
				date = items[index].Date;
				open = items[index].Open;
				high = items[index].High;
				low = items[index].Low;
				close = items[index].Close;
				volume = items[index].Volume;

				index++;
				while ((index < items.Count) && TimeFrameDurations.Start(Timeframe, date) == TimeFrameDurations.Start(Timeframe, items[index].Date))
				{
					//date = items[index].Date;
					high = Math.Max(high, items[index].High);
					low = Math.Min(low, items[index].Low);
					close = items[index].Close;
					volume += items[index].Volume;

					index++;
				}

				newItems.Add(new DataItem(date, open, high, low, close, volume));
			}

			if ((newItems != null) && (newItems.Count > 0))
				OnDataAdded(newItems);
		}

		public void Dump()
		{
/*
			Console.WriteLine("->DataView Timeframe = {0}", Timeframe);

			foreach (IDataItem item in this._dataItems)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine("<-DataView Timeframe = {0}", Timeframe);
*/
		}
	}


	public class MovingAverageDefinition : IMovingAverageDefinition
	{
		public MovingAverageType MovingAverageType { get; private set; }
		public int Period { get; private set; }
		public PriceFormula Formula { get; private set; }

		public MovingAverageDefinition(MovingAverageType type, int period, PriceFormula formula)
		{
			MovingAverageType = type;
			Period = period;
			Formula = formula;
		}

		public override bool Equals(object obj)
		{
			MovingAverageDefinition mad = obj as MovingAverageDefinition;
			if (mad == null)
				return false;

			if ((mad.MovingAverageType == this.MovingAverageType) &&
					(mad.Formula == this.Formula) &&
					(mad.Period == this.Period))
				return true;

			return false;
		}
	}
}

