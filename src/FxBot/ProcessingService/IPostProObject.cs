using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessingService
{
	public interface IPostProObject
	{
		void Initialize(ProcessingService service);
		void Execute();
	}
}
