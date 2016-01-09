using System;
using System.Collections.Generic;
using System.Text;

namespace DataCommon
{
	public interface IDataView
	{
		TimeFrame Timeframe { get; }

		IList<IDataItem> DataCollection { get; }
		// Moving Average stuff
		//IList<double> AddMovingAverageCollection(MovingAverageType type, int period, PriceFormula formula);
		//IList<double> GetMovingAverageCollection(MovingAverageType type, int period, PriceFormula formula, bool createNew);
		//IList<double> GetMovingAverageCollection(IMovingAverageDefinition filter, bool createNew);
		int AddMovingAverageCollection();
		IList<double> GetMovingAverageCollection(int id);

		// Gaps stuff
		IList<IGapItem> AddGapCollection();
		IList<IGapItem> GetGapCollection(bool createNew);

		// Trend stuff
		IList<int> AddTrendCollection();
		IList<int> GetTrendCollection(bool createNew);

		// Indicator stuff
		IList<double> AddIndicatorCollection(IndicatorType type, int period);



		event DataAddedEventHandler DataAdded;
		event DataChangedEventHandler DataChanged;
		void ProcessingCompleted(object sender, ProcessingCompletedEventArgs args);
	}
}
