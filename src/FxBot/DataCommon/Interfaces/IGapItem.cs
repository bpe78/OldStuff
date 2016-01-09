using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCommon
{
	public interface IGapItem
	{
		int X { get; }
		double Top { get; }
		double Bottom { get; }
		bool IsFullGap { get; }
		GapTypes GapType { get; }
		GapSize Size { get; }
	}

	public enum GapTypes
	{
		NotSet = 0,
		Area,
		Breakaway,
		Continuation,
		Exhaustion
	}

	public enum GapSize
	{
		NotSet,
		Small,
		Large
	}
}
