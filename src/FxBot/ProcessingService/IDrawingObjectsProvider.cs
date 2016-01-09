using System;
using System.Collections.Generic;
using System.Text;


namespace ProcessingService
{
	public interface IDrawingObjectsProvider
	{
		IList<ChartElement> GetDrawingObjects(int x1, int x2);
		int Count { get; }
	}


}
