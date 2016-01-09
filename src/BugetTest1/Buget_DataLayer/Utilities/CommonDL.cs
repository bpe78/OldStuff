using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace Buget_DataLayer
{
  public static class CommonDL
  {
    private static string _connectionString = "Data Source=(local); Initial Catalog=BugetTest1; Integrated Security=true;";
    private static List<CurrencyObjectInfo> _listCurrencies = null;
    private static List<FrequencyObjectInfo> _listFrequencies = null;

    public static string ConnectionString
    {
      get { return CommonDL._connectionString; }
    }

    public static List<CurrencyObjectInfo> GetCurrencyList()
    {
      if ((_listCurrencies != null) && (_listCurrencies.Count > 0))
        return _listCurrencies;

      using (SqlConnection conn = new SqlConnection(_connectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = String.Format("SELECT {1}, {2} FROM {0}", CurrencyDL.TableName, CurrencyDL.ID, CurrencyDL.Name);

          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.HasRows)
            {
              _listCurrencies = new List<CurrencyObjectInfo>();

              while (reader.Read())
              {
                _listCurrencies.Add(new CurrencyObjectInfo(reader.GetByte(0), reader.GetString(1)));
              }
            }

            reader.Close();
          }
        }

        conn.Close();

        return _listCurrencies;
      }
    }

    public static List<FrequencyObjectInfo> GetFrequencyList()
    {
      if ((_listFrequencies != null) && (_listFrequencies.Count > 0))
        return _listFrequencies;

      using (SqlConnection conn = new SqlConnection(_connectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = String.Format("SELECT {0}, {1} FROM {2}", FrequencyDL.ID, FrequencyDL.Name, FrequencyDL.TableName);

          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.HasRows)
            {
              _listFrequencies = new List<FrequencyObjectInfo>();

              while (reader.Read())
              {
                _listFrequencies.Add(new FrequencyObjectInfo(reader.GetByte(0), reader.GetString(1)));
              }
            }

            reader.Close();
          }
        }

        conn.Close();

        return _listFrequencies;
      }
    }

  }
}
