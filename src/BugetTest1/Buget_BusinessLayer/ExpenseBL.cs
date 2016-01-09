using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;
using Buget_DataLayer;

namespace Buget_BusinessLayer
{
  public static class ExpenseBL
  {
    private static List<ExpenseTypesObjectInfo> _listExpenseTypes = null;

    public static List<ExpenseTypesObjectInfo> GetExpenseTypesList()
    {
      if ((_listExpenseTypes != null) && (_listExpenseTypes.Count > 0))
        return _listExpenseTypes;

      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = String.Format("SELECT {1}, {2} FROM {0}", ExpenseTypesDL.TableName, ExpenseTypesDL.ID, ExpenseTypesDL.Name);

          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.HasRows)
            {
              _listExpenseTypes = new List<ExpenseTypesObjectInfo>();

              while (reader.Read())
              {
                _listExpenseTypes.Add(new ExpenseTypesObjectInfo(reader.GetInt16(0), reader.GetString(1), false, 0, false, 0, 0, DateTime.Now, DateTime.Now));
              }
            }

            reader.Close();
          }
        }

        conn.Close();

        return _listExpenseTypes;
      }
    }

    public static decimal GetExpense(DateTime dtStart, DateTime dtEnd, byte id_Currency)
    {
      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = String.Format("SELECT udfExpenses({0}, {1}, {2})", dtStart.ToShortDateString(), dtEnd.ToShortDateString(), id_Currency);

          return (decimal)cmd.ExecuteScalar();
        }
      }
    }

    public static void AddExpense_New(DateTime date, short idType, decimal amount, string details, byte idCurrency, bool addBankTransaction)
    {
      //TODO: validate input

      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "uspExpenseAdd_New";

          cmd.Parameters.AddWithValue(ExpenseDL.Date, date);
          cmd.Parameters.AddWithValue(ExpenseDL.IdType, idType);
          cmd.Parameters.AddWithValue(ExpenseDL.Amount, amount);
          cmd.Parameters.AddWithValue(ExpenseDL.Details, details);
          cmd.Parameters.AddWithValue(ExpenseDL.IdCurrency, idCurrency);
          cmd.Parameters.AddWithValue(ExpenseDL.UseBankAccount, addBankTransaction);
          cmd.Parameters.Add("IdNewEntry", SqlDbType.Int);
          cmd.Parameters["IdNewEntry"].Direction = ParameterDirection.Output;

          cmd.ExecuteNonQuery();
        }

        conn.Close();
      }
    }

    public static void AddExpenseType(string name, bool useBankAccount, byte? idAccount, bool isRegularPayment, byte? frequency, short? counterFrequency, DateTime? startDate, DateTime? endDate)
    {
      //TODO: validate input

      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "uspExpenseAddType";

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
      if (_listExpenseTypes != null)
      {
        _listExpenseTypes.Clear();
        _listExpenseTypes = null;
      }
    }
  }
}
