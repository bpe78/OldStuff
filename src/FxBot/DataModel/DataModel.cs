using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataCommon;

namespace DataModel
{
	public class DataModel
	{
		private static string ConnectionString
		{
			get
			{
				//TODO: get these parameters from somewhere !!!
				string server = "localhost";
				string database = "ForexData";

				return String.Format("Server={0};Initial Catalog={1};Integrated Security=true", server, database);
			}
		}

		private static string CommandText
		{
			get
			{
				//TODO: get these parameters from somewhere !!!
				string table = @"EUR_USD_M01";

				return String.Format(@"SELECT D, T, O, H, L, C, V FROM {0} ORDER BY D, T", table);
			}
		}

		public static IList<IDataItem> LoadDataCollection(int timeframe)
		{
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				conn.Open();

				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = CommandText;
				cmd.CommandType = CommandType.Text;

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						List<IDataItem> items = new List<IDataItem>();

						while (reader.Read())
						{
							DateTime date = reader.GetDateTime(0);
							date = date.Add(reader.GetTimeSpan(1));
							double open = (double)reader.GetDecimal(2);
							double high = (double)reader.GetDecimal(3);
							double low = (double)reader.GetDecimal(4);
							double close = (double)reader.GetDecimal(5);
							long volume = reader.GetInt32(6);

							items.Add(new DataItem(date, open, high, low, close, volume));

							//if (items.Count == 100)
							//	break;
						}

						return items;
					}
				}
			}

			return null;
		}

		public static IList<ITrendItem> LoadTrendCollection(int timeframe)
		{
			throw new NotImplementedException();
		}

		public static IList<double> LoadMovingAverageCollection(int timeframe)
		{
			throw new NotImplementedException();
		}

		public static IList<IGapItem> LoadGapCollection(int timeframe)
		{
			throw new NotImplementedException();
		}

	}
}
