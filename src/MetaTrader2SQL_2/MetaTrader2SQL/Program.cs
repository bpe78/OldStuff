using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

namespace MetaTrader2SQL
{
	class DataItem
	{
		public DateTime D { get; set; }
		public DateTime T { get; set; }
		public decimal O { get; set; }
		public decimal H { get; set; }
		public decimal L { get; set; }
		public decimal C { get; set; }
		public int V { get; set; }

		public DataItem(DateTime d, DateTime t, decimal o, decimal h, decimal l, decimal c, int v)
		{
			D = d;
			T = t;
			O = o;
			H = h;
			L = l;
			C = c;
			V = v;
		}
	}

	class Program
	{
		/*
				static void Main(string[] args)
				{
					string[,] items = new string[9, 3] { {"uspAddM01",  "EUR_USD_M01", @"d:\EURUSD.1.csv"},
																							{"uspAddM05",  "EUR_USD_M05", @"d:\EURUSD.5.csv"},
																							{"uspAddM15", "EUR_USD_M15", @"d:\EURUSD.15.csv"}, 
																							{"uspAddM30", "EUR_USD_M30", @"d:\EURUSD.30.csv"}, 
																							{"uspAddH1",  "EUR_USD_H1", @"d:\EURUSD.60.csv"}, 
																							{"uspAddH4",  "EUR_USD_H4", @"d:\EURUSD.240.csv"}, 
																							{"uspAddD1",  "EUR_USD_D1", @"d:\EURUSD.1440.csv"}, 
																							{"uspAddW1",  "EUR_USD_W1", @"d:\EURUSD.10080.csv"}, 
																							{"uspAddMN",  "EUR_USD_MN", @"d:\EURUSD.43200.csv"} };

					using (SqlConnection conn = new SqlConnection("Server=.;Database=ForexData;Integrated Security=true"))
					{
						conn.Open();

						using (SqlCommand cmd = new SqlCommand())
						{
							cmd.CommandType = CommandType.Text;
							cmd.Connection = conn;

							for (int i = 0; i < 1; i++)
							{
								string procedure = items[i, 0];
								string filename = items[i, 2];

								if (!File.Exists(filename))
									break;
								Dictionary<DateTime, DataItem> _items = new Dictionary<DateTime, DataItem>();
								using (StreamReader sr = new StreamReader(filename))
								{
									int errors = 0;
									while (!sr.EndOfStream)
									{
										string line = sr.ReadLine();

										string[] tokens = line.Split(new char[] { ',' });

										DateTime d, t;
										decimal o, h, l, c;
										int v;
										bool b;
										b = DateTime.TryParse(tokens[0], out d);
										System.Diagnostics.Debug.Assert(b);

										b = DateTime.TryParse(tokens[1], out t);
										System.Diagnostics.Debug.Assert(b);
								
										b = decimal.TryParse(tokens[2], out o);
										System.Diagnostics.Debug.Assert(b);
								
										b = decimal.TryParse(tokens[3], out h);
										System.Diagnostics.Debug.Assert(b);
								
										b = decimal.TryParse(tokens[4], out l);
										System.Diagnostics.Debug.Assert(b);
								
										b = decimal.TryParse(tokens[5], out c);
										System.Diagnostics.Debug.Assert(b);
								
										b = int.TryParse(tokens[6], out v);
										System.Diagnostics.Debug.Assert(b);

										if (_items.ContainsKey(d.Add(new TimeSpan(t.Hour, t.Minute, t.Second))))
											errors++;
										else
											_items.Add(d.Add(t.TimeOfDay), new DataItem(d, t, o, h, l, c, v));
									}
								}

								int sleepCounter = 0;
								int n = 15000;
								foreach (DateTime key in _items.Keys)
								{
									string s;
									DataItem item = _items[key];
									string time = String.Format("{0}:{1}:00", item.T.Hour, item.T.Minute);
									s = String.Format("INSERT INTO EUR_USD_M01(D, T, O, H, L, C, V) VALUES ('{0}', '{1}', {2}, {3}, {4}, {5}, {6})", item.D, time, item.O, item.H, item.L, item.C, item.V);
									cmd.CommandText = s;
									cmd.ExecuteNonQuery();

									sleepCounter++;
									if(sleepCounter % 10000 == 0)
										Thread.Sleep(n);
								}
							}
						}
					}
				}
		*/
		static void Main(string[] args)
		{
			string[,] items = new string[9, 3] { {"uspAddM01", "EUR_USD_M01", @"d:\EURUSD1.csv"},
																				  {"uspAddM05", "EUR_USD_M05", @"d:\EURUSD5.csv"},
																					{"uspAddM15", "EUR_USD_M15", @"d:\EURUSD15.csv"}, 
																					{"uspAddM30", "EUR_USD_M30", @"d:\EURUSD30.csv"}, 
																					{"uspAddH1",  "EUR_USD_H1",  @"d:\EURUSD60.csv"}, 
																					{"uspAddH4",  "EUR_USD_H4",  @"d:\EURUSD240.csv"}, 
																					{"uspAddD1",  "EUR_USD_D1",  @"d:\EURUSD1440.csv"}, 
																					{"uspAddW1",  "EUR_USD_W1",  @"d:\EURUSD10080.csv"}, 
																					{"uspAddMN",  "EUR_USD_MN",  @"d:\EURUSD43200.csv"} };

			using (SqlConnection conn = new SqlConnection("Server=.;Database=ForexData;Integrated Security=true"))
			{
				conn.Open();

				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = conn;

					for (int i = 0; i < items.GetLength(0); i++)
					{
						// Find the last session
						DateTime lastSession = DateTime.MinValue;
						using (SqlCommand cmd1 = new SqlCommand())
						{
							cmd1.CommandType = CommandType.Text;
							cmd1.Connection = conn;

							// Find the last day
							cmd1.CommandText = "SELECT MAX(D) FROM " + items[i, 1];
							using (SqlDataReader reader = cmd1.ExecuteReader())
							{
								if (reader.HasRows)
								{
									if (reader.Read())
									{
										lastSession = reader.GetDateTime(0);
									}
								}
							}

							// Find the lastSession time of the lastSession day
							cmd1.CommandText = "SELECT MAX(T) FROM " + items[i, 1] + " WHERE (D = '" + lastSession.ToString("yyyy/MM/dd") + "')";
							using (SqlDataReader reader = cmd1.ExecuteReader())
							{
								if (reader.HasRows)
								{
									if (reader.Read())
									{
										TimeSpan time = reader.GetTimeSpan(0);
										lastSession = lastSession.Add(time);
									}
								}
							}
						}

						string procedure = items[i, 0];
						string filename = items[i, 2];

						cmd.CommandText = procedure;
						if (!File.Exists(filename))
							continue;

						Console.WriteLine("Processing file : {0}", filename);
						using (StreamReader sr = new StreamReader(filename))
						{
							int sleepCounter = 0;
							while (!sr.EndOfStream)
							{
								string line = sr.ReadLine();

								string[] tokens = line.Split(new char[] { ',' });

								DateTime d, t;
								decimal o, h, l, c;
								int v;
								bool b;
								b = DateTime.TryParse(tokens[0], out d);
								System.Diagnostics.Debug.Assert(b);
								b = DateTime.TryParse(tokens[1], out t);
								System.Diagnostics.Debug.Assert(b);

								// Check if this is a new session
								DateTime tmp = d.Add(new TimeSpan(t.Hour, t.Minute, t.Second));

								b = decimal.TryParse(tokens[2], out o);
								System.Diagnostics.Debug.Assert(b);
								b = decimal.TryParse(tokens[3], out h);
								System.Diagnostics.Debug.Assert(b);
								b = decimal.TryParse(tokens[4], out l);
								System.Diagnostics.Debug.Assert(b);
								System.Diagnostics.Debug.Assert(b);
								b = decimal.TryParse(tokens[5], out c);
								System.Diagnostics.Debug.Assert(b);
								b = int.TryParse(tokens[6], out v);
								System.Diagnostics.Debug.Assert(b);

								if (lastSession >= tmp)
								{
									using (SqlCommand cmdTmp = new SqlCommand())
									{
										cmdTmp.CommandType = CommandType.Text;
										cmdTmp.Connection = conn;

										cmdTmp.CommandText = "UPDATE " + items[i, 1] + " SET O = " + o.ToString() + ", H = " + h.ToString() + ", L = " + l.ToString() + ", C = " + c.ToString() + ", V = " + v.ToString() + " WHERE (D = '" + d.ToString("yyyy/MM/dd") + "' AND T = '" + t.ToString("hh:mm:ss") + "')";
										cmdTmp.ExecuteNonQuery();
									}
								}
								else
								{
									cmd.Parameters.Clear();
									cmd.Parameters.AddWithValue("D", d);
									cmd.Parameters.AddWithValue("T", t);
									cmd.Parameters.AddWithValue("O", o);
									cmd.Parameters.AddWithValue("H", h);
									cmd.Parameters.AddWithValue("L", l);
									cmd.Parameters.AddWithValue("C", c);
									cmd.Parameters.AddWithValue("V", v);

									cmd.ExecuteNonQuery();
								}

								sleepCounter++;
								if (sleepCounter % 5000 == 0)
								{
									Console.WriteLine("Processing time : {0} {1}", d.ToShortDateString(), t.ToShortTimeString());

									Thread.Sleep(15000);
								}
								else if (sleepCounter % 1000 == 0)
								{
									Console.WriteLine("Processing time : {0} {1}", d.ToShortDateString(), t.ToShortTimeString());

									Thread.Sleep(1000);
								}
							}
						}

						//break;
						Thread.Sleep(5000);
					}
				}
			}
		}
	}
}
