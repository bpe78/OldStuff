using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;
using Buget_DataLayer;

namespace Buget_BusinessLayer
{
  public static class FrequencyBL
  {
    private static List<FrequencyObjectInfo> _listFrequencies = null;

    public static List<FrequencyObjectInfo> GetFrequencyList()
    {
      if ((_listFrequencies != null) && (_listFrequencies.Count > 0))
        return _listFrequencies;

      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = String.Format("SELECT {1}, {2} FROM {0}", FrequencyDL.TableName, FrequencyDL.ID, FrequencyDL.Name);

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
