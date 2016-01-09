using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
	/*public struct Point2D
	{
		public int X;
		public int Y;
	}*/

	public struct Point2D : IEquatable<Point2D>
	{
		public int X;
		public int Y;

		public override bool Equals(object obj)
		{
			if (!(obj is Point2D))
				return false;
			Point2D other = (Point2D)obj;
			return (X == other.X) && (Y == other.Y);
		}

		public bool Equals(Point2D other)
		{
			return (X == other.X) && (Y == other.Y);
		}
		
		public static bool operator ==(Point2D a, Point2D b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Point2D a, Point2D b)
		{
			return !(a == b);
		}
	}
}
