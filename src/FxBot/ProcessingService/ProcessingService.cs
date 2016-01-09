using System;
using System.Collections.Generic;
using System.Text;
using DataCommon;
using System.Threading;
using TrendEngine;
using MovingAverageEngine;
using GapsEngine;
using IndicatorsEngine;

namespace ProcessingService
{
	public class ProcessingService : IDrawingObjectsProvider
	{
		IDataView _dataCollection;

		// Collection of Moving Average Calculator classes
		Dictionary<int, KeyValuePair<PriceCalculator, IMovingAverageCalculator>> _movingAverageCalculators;

		// Gaps Calculator
		IGapCalculator _gapCalculator;

		// Trends Calculator
		ITrendCalculator _trendCalculator;
		//List<ExtremePoint> _extremePoints;

		public ProcessingService()
		{
			_dataCollection = null;

			_movingAverageCalculators = new Dictionary<int, KeyValuePair<PriceCalculator, IMovingAverageCalculator>>();
		}

		public void Initialize(IDataView dataView)
		{
			if (dataView == null)
				throw new ArgumentNullException();

			if (_dataCollection != dataView)
			{
				if (_dataCollection != null)
				{
					this.ProcessingCompleted -= _dataCollection.ProcessingCompleted;
				}

				_dataCollection = dataView;

				this.ProcessingCompleted += _dataCollection.ProcessingCompleted;

				// Initialize all moving average calculators
				foreach (int id in _movingAverageCalculators.Keys)
				{
					IMovingAverageCalculator ma = _movingAverageCalculators[id].Value;
					ma.Reset();
				}

				// Initialize the trend calculator
				InitializeTrendCalculator();

				// Initialize the gap calculator
				InitializeGapCalculator();

				// Initialize the trend calculator
				InitializeTrendCalculator();
			}
		}

		public event ProcessingCompletedEventHandler ProcessingCompleted;

		private void OnProcessingFinished()
		{
			if (ProcessingCompleted != null)
				ProcessingCompleted(this, new ProcessingCompletedEventArgs());
		}

		public void DataAdded(object sender, DataAddedEventArgs args)
		{
			IDataView dataCollection = sender as IDataView;

			System.Diagnostics.Debug.Assert(_dataCollection == dataCollection);
			if(_dataCollection != dataCollection)
				throw new InvalidOperationException();

			//ThreadPool.QueueUserWorkItem(new WaitCallback(DoProcessing));
			DoProcessing(null);
		}

		public void DataChanged(object sender, DataChangedEventArgs args)
		{
			IDataView dataCollection = sender as IDataView;

			System.Diagnostics.Debug.Assert(_dataCollection == dataCollection);
			if (_dataCollection != dataCollection)
				throw new InvalidOperationException();

			//ThreadPool.QueueUserWorkItem(new WaitCallback(DoProcessingChanged));
			DoProcessingChanged(null);
		}

		private void DoProcessing(object o)
		{
			bool dataAdded = true;
			//TODO: add computations here

			UpdateTrends(dataAdded);

			UpdateMovingAverages(dataAdded);

			UpdateGapCalculator(dataAdded);

			UpdatePostProcessing();

			OnProcessingFinished();
		}

		private void DoProcessingChanged(object o)
		{
			bool dataAdded = false;
			//TODO: add computations here

			UpdateTrends(dataAdded);

			UpdateMovingAverages(dataAdded);

			UpdateGapCalculator(dataAdded);

			OnProcessingFinished();
		}

		#region IDrawingObjectsProvider Members

		public IList<ChartElement> GetDrawingObjects(int x1, int x2)
		{
			List<ChartElement> elements = new List<ChartElement>();

			int x = 0;
			foreach (IDataItem candle in _dataCollection.DataCollection)
			{
				if((x >= x1) && (x <= x2))
					elements.Add(new Candlestick(x, candle.Open, candle.High, candle.Low, candle.Close));
				x++;
			}

			ExtremePoint last = null;
			foreach (ExtremePoint ep in _trendCalculator.Trends)
			{
				if (last != null)
				{
					if ((last.X <= x2) && (ep.X >= x1))
					{
						elements.Add(new Trendline(last.X, last.Value, ep.X, ep.Value));
					}
				}

				last = ep;
			}

/*
			// Tmp stuff
			last = null;
			List<ExtremePoint> _tmpList = _trendCalculator.GetStrongTrends();
			foreach (ExtremePoint ep in _tmpList)
			{
				if (last != null)
				{
					if ((last.X <= x2) && (ep.X >= x1))
					{
						//elements.Add(new Trendline(last.X, last.Value, ep.X, ep.Value));
					}
				}

				last = ep;
			}
			// End Tmp stuff
*/
/*
			List<TradingRange> tradingRanges = _trendCalculator.FindTradingRanges8();
			foreach (TradingRange tr in tradingRanges)
			{
				elements.Add(new TradingRangeBox(tr.X1, tr.X2, tr.Min, tr.Max));
			}
*/

			// Add moving average graphics to the UI
			foreach (int id in _movingAverageCalculators.Keys)
			{
				IList<double> values = _dataCollection.GetMovingAverageCollection(id);
				elements.Add(new MovingAverage(x1, x2, values));
			}

			// Add gap graphics to the UI
			foreach (IGapItem gap in _gapCalculator.Values)
			{
				if ((x1 < gap.X) && (gap.X < x2))
					elements.Add(new Gap(gap.X, gap.Top, gap.Bottom, gap.IsFullGap));
			}

			return elements;
		}

		public int Count
		{
			get
			{
				return _dataCollection.DataCollection.Count;
			}
		}

		#endregion

		public IList<double> AddMovingAverageCalculator(MovingAverageType type, int period, PriceFormula formula)
		{
			IMovingAverageCalculator ma;

			switch (type)
			{
				case MovingAverageType.Simple :
					ma = new SimpleMACalculator();
					break;

				case MovingAverageType.Exponential:
					ma = new ExponentialMACalculator();
					break;

				default: throw new NotImplementedException();
			}

			int id = _dataCollection.AddMovingAverageCollection();
			_movingAverageCalculators.Add(id, new KeyValuePair<PriceCalculator, IMovingAverageCalculator>(GetPriceCalculator(formula), ma));

			IList<double> values = _dataCollection.GetMovingAverageCollection(id);
			System.Diagnostics.Debug.Assert(values != null);
			if (values == null)
				throw new InvalidOperationException();

			ma.Initialize(period);
			return values;
		}

		public IList<double> AddIndicatorCalculator(IndicatorType type, int period)
		{
			IIndicatorCalculator calculator = GetIndicator(type);
			IList<double> values = _dataCollection.AddIndicatorCollection(type, period);
			calculator.Initialize(period, _dataCollection.DataCollection, values);
			return values;
		}

		public void InitializeGapCalculator()
		{
			if (_gapCalculator == null)
				_gapCalculator = new GapCalculator();

			IList<IGapItem> gapValues = _dataCollection.GetGapCollection(true);
			System.Diagnostics.Debug.Assert(gapValues != null);
			if (gapValues == null)
				throw new InvalidOperationException();

			_gapCalculator.Initialize(_dataCollection.DataCollection, gapValues);
		}

		public void InitializeTrendCalculator()
		{
			if (_trendCalculator == null)
				_trendCalculator = new TrendCalculatorIncremental();

			IList<int> trendValues = _dataCollection.GetTrendCollection(true);
			System.Diagnostics.Debug.Assert(trendValues != null);
			if (trendValues == null)
				throw new InvalidOperationException();

			_trendCalculator.Initialize(_dataCollection.DataCollection, trendValues);
		}

		#region Helper Methods

		private void UpdateTrends(bool dataAdded)
		{
			if (_trendCalculator == null)
				throw new InvalidOperationException();

			_trendCalculator.Calculate(dataAdded);

				//_extremePoints = _trendCalculator.CalculateTrends();
		}

		private void UpdateMovingAverages(bool dataAdded)
		{
			if (_movingAverageCalculators == null)
				throw new InvalidOperationException();

			foreach (int id in _movingAverageCalculators.Keys)
			{
				KeyValuePair<PriceCalculator, IMovingAverageCalculator> kvp = _movingAverageCalculators[id];
				PriceCalculator priceCalculator = kvp.Key;
				IMovingAverageCalculator maCalculator = kvp.Value;

				double value = maCalculator.Calculate(priceCalculator(_dataCollection.DataCollection[_dataCollection.DataCollection.Count-1]), dataAdded);
				_dataCollection.GetMovingAverageCollection(id)[_dataCollection.DataCollection.Count - 1] = value;
			}
		}

		private void UpdateGapCalculator(bool dataAdded)
		{
			if (_gapCalculator == null)
				throw new InvalidOperationException();

			_gapCalculator.Calculate(dataAdded);
		}

		private PriceCalculator GetPriceCalculator(PriceFormula priceFormula)
		{
			switch (priceFormula)
			{
				case PriceFormula.Close: return DataUtilities.PriceUtilities.Close;
				case PriceFormula.High: return DataUtilities.PriceUtilities.High;
				case PriceFormula.Low: return DataUtilities.PriceUtilities.Low;
				case PriceFormula.Open: return DataUtilities.PriceUtilities.Open;
				case PriceFormula.TypicalPrice: return DataUtilities.PriceUtilities.TypicalPrice;
				case PriceFormula.MedianPrice: return DataUtilities.PriceUtilities.MedianPrice;
				case PriceFormula.WeightedPrice: return DataUtilities.PriceUtilities.WeightedPrice;
				default: throw new NotSupportedException();
			}
		}

		private IIndicatorCalculator GetIndicator(IndicatorType type)
		{
			switch (type)
			{
				case IndicatorType.RSI: return new RSICalculator();
				case IndicatorType.Momentum: return new MomentumCalculator();
				case IndicatorType.ParabolicSAR: return new ParabolicSARCalculator();
				//case IndicatorType.MACD: return new MACDCalculator();
				default: throw new ArgumentOutOfRangeException();
			}
		}

		private void UpdatePostProcessing()
		{
			foreach (IPostProObject pp in _ppObjects)
			{
				pp.Execute();
			}
		}

		#endregion



		List<IPostProObject> _ppObjects = new List<IPostProObject>();
		public void AddPostProObject(IPostProObject pp)
		{
			pp.Initialize(this);
			_ppObjects.Add(pp);
		}
	}
}
