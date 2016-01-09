using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;
using Buget_DataLayer;

namespace Buget_BusinessLayer
{
  public static class IncomeBL
  {
    private static List<IncomeTypesObjectInfo> _listIncomeTypes = null;

    public static List<IncomeTypesObjectInfo> GetIncomeTypesList()
    {
      if ((_listIncomeTypes != null) && (_listIncomeTypes.Count > 0))
        return _listIncomeTypes;

      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = String.Format("SELECT {1}, {2} FROM {0}", IncomeTypesDL.TableName, IncomeTypesDL.ID, IncomeTypesDL.Name);

          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.HasRows)
            {
              _listIncomeTypes = new List<IncomeTypesObjectInfo>();

              while (reader.Read())
              {
                _listIncomeTypes.Add(new IncomeTypesObjectInfo(reader.GetInt16(0), reader.GetString(1), false, 0, false, 0, 0, DateTime.Now, DateTime.Now));
              }
            }

            reader.Close();
          }
        }

        conn.Close();

        return _listIncomeTypes;
      }
    }

    public static void AddIncome_New(DateTime date, short idType, decimal amount, string details, byte idCurrency, bool addBankTransaction)
    {
      //TODO: validate input

      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "uspIncomeAdd_New";

          cmd.Parameters.AddWithValue(IncomeDL.Date, date);
          cmd.Parameters.AddWithValue(IncomeDL.IdType, idType);
          cmd.Parameters.AddWithValue(IncomeDL.Amount, amount);
          cmd.Parameters.AddWithValue(IncomeDL.Details, details);
          cmd.Parameters.AddWithValue(IncomeDL.IdCurrency, idCurrency);
          cmd.Parameters.AddWithValue(IncomeDL.UseBankAccount, addBankTransaction);
          cmd.Parameters.Add("IdNewEntry", SqlDbType.Int);
          cmd.Parameters["IdNewEntry"].Direction = ParameterDirection.Output;

          cmd.ExecuteNonQuery();
        }

        conn.Close();
      }
    }

    public static void AddIncomeType(string name, bool useBankAccount, byte? idAccount, bool isRegularPayment, byte? frequency, short? counterFrequency, DateTime? startDate, DateTime? endDate)
    {
      //TODO: validate input

      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "uspIncomeAddType";

          cmd.Parameters.AddWithValue("@Name", name);
          cmd.Parameters.AddWithValue("@UseBankAccount", useBankAccount);
          cmd.Parameters.AddWithValue("@Id_Account", idAccount);
          cmd.Parameters.AddWithValue("@IsRegularPayment", isRegularPayment);
          cmd.Parameters.AddWithValue("@Frequency", frequency);
          cmd.Parameters.AddWithValue("@FrequencyCounter", counterFrequency);
          cmd.Parameters.AddWithValue("@StartingDate", startDate);
          cmd.Parameters.AddWithValue("@EndingDate", endDate);

          cmd.ExecuteNonQuery();
        }

        conn.Close();
      }

      // Force refresh on the associated list
      if (_listIncomeTypes != null)
      {
        _listIncomeTypes.Clear();
        _listIncomeTypes = null;
      }
    }

    public static decimal GetTotal(DateTime dtStart, DateTime dtEnd, short idType)
    {
      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "uspIncomeGetTotal";
          cmd.Parameters.AddWithValue("startDate", dtStart.ToShortDateString());
          cmd.Parameters.AddWithValue("endDate", dtEnd.ToShortDateString());
          cmd.Parameters.AddWithValue("type", 1);
          cmd.Parameters.AddWithValue("total", SqlDbType.Money);
          cmd.Parameters["total"].Direction = ParameterDirection.Output;

          cmd.ExecuteNonQuery();


          decimal total = (decimal)cmd.Parameters["total"].Value;
          return total;
        }
      }
    }
  }
}
