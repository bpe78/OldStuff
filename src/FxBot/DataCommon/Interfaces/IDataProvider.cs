using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCommon
{
	public interface IDataProvider
	{
		event DataReceivedEventHandler DataReceived;

		void Start();
		void Stop();
		void Pause();
	}
}
