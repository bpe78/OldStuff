using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCommon
{
	public class ProcessingCompletedEventArgs : EventArgs
	{
		public ProcessingCompletedEventArgs()
		{
		}
	}

	public delegate void ProcessingCompletedEventHandler(object sender, ProcessingCompletedEventArgs args);

}
