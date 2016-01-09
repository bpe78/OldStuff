using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Buget_DataLayer;
using System.Data;
using System.Data.SqlClient;

namespace Buget_BusinessLayer
{
  public static class CurrencyBL
  {
    private static List<CurrencyObjectInfo> _listCurrencies = null;

    public static List<CurrencyObjectInfo> GetCurrencyList()
    {
      if ((_listCurrencies != null) && (_listCurrencies.Count > 0))
        return _listCurrencies;

      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
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
  }
}
