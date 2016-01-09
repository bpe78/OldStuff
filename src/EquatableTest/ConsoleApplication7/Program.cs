using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
	class Program
	{
		static void Main(string[] args)
		{
			const int size = 10 * 1000 * 1000;
			var sw = Stopwatch.StartNew();
			var points = new List<Point2D>(size);
			Checkpoint(sw);

			for (int i = 0; i < size; i++)
			{
				points.Add(new Point2D { X = 2 * i, Y = i });
			}
			Checkpoint(sw);

			var r = new Point2D { X = 1, Y = 10 };
			if(points.Contains(r))
				Console.WriteLine("Punctul a fost gasit");
			else
				Console.WriteLine("Punctul nu exista");
			Checkpoint(sw);

			Console.ReadLine();
		}

		static void Checkpoint(Stopwatch sw)
		{
			sw.Stop();
			Console.WriteLine("ticks = {0}", sw.ElapsedTicks);
			sw.Restart();
		}
	}
}
