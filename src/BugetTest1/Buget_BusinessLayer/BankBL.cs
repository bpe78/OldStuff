using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buget_DataLayer;
using Common;
using System.Data;
using System.Data.SqlClient;

namespace Buget_BusinessLayer
{
  public static class BankBL
  {
    private static List<BankAccountsObjectInfo> _listBankAccounts = null;
    private static List<BankDetailsObjectInfo> _listBankDetails = null;
    private static List<BankTypesObjectInfo> _listBankTypes = null;

    public static List<BankAccountsObjectInfo> GetAccountsList()
    {
      if ((_listBankAccounts != null) && (_listBankAccounts.Count > 0))
        return _listBankAccounts;

      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = String.Format("SELECT {1}, {2}, {3}, {4}, {5}, {6}, {7} FROM {0}", BankAccountsDL.TableName, BankAccountsDL.ID, BankAccountsDL.Name, BankAccountsDL.Description, BankAccountsDL.IBAN, BankAccountsDL.Issuer, BankAccountsDL.Currency, BankAccountsDL.InvestmentAccount);

          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.HasRows)
            {
              _listBankAccounts = new List<BankAccountsObjectInfo>();

              while (reader.Read())
              {
                _listBankAccounts.Add(new BankAccountsObjectInfo(reader.GetByte(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetByte(4), reader.GetByte(5), reader.GetBoolean(6)));
              }
            }

            reader.Close();
          }
        }

        conn.Close();

        return _listBankAccounts;
      }
    }

    public static List<BankDetailsObjectInfo> GetBankDetailsList()
    {
      if ((_listBankDetails != null) && (_listBankDetails.Count > 0))
        return _listBankDetails;

      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = String.Format("SELECT {0}, {1} FROM {2}", BankDetailsDL.ID, BankDetailsDL.Name, BankDetailsDL.TableName);

          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.HasRows)
            {
              _listBankDetails = new List<BankDetailsObjectInfo>();

              while (reader.Read())
              {
                _listBankDetails.Add(new BankDetailsObjectInfo(reader.GetByte(0), reader.GetString(1), string.Empty));
              }
            }

            reader.Close();
          }
        }

        conn.Close();

        return _listBankDetails;
      }
    }

    public static List<BankTypesObjectInfo> GetBankTypesList()
    {
      if ((_listBankTypes != null) && (_listBankTypes.Count > 0))
        return _listBankTypes;

      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = String.Format("SELECT {1}, {2}, {3} FROM {0}", BankTypesDL.TableName, BankTypesDL.ID, BankTypesDL.Name, BankTypesDL.Income);

          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.HasRows)
            {
              _listBankTypes = new List<BankTypesObjectInfo>();

              while (reader.Read())
              {
                _listBankTypes.Add(new BankTypesObjectInfo(reader.GetByte(0), reader.GetString(1), reader.GetBoolean(2)));
              }
            }

            reader.Close();
          }
        }

        conn.Close();

        return _listBankTypes;
      }
    }

    public static void AddBankAccount(string name, string description, string IBAN, byte idBank, byte idCurrency, bool isInvestmentAccount)
    {
      //TODO: validate input

      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "uspBankAccountsAdd";

          cmd.Parameters.AddWithValue("Name", name);
          cmd.Parameters.AddWithValue("Description", description);
          cmd.Parameters.AddWithValue("IBAN", IBAN);
          cmd.Parameters.AddWithValue("Id_Issuer", idBank);
          cmd.Parameters.AddWithValue("Id_Currency", idCurrency);
          cmd.Parameters.AddWithValue("InvestmentAccount", isInvestmentAccount);
          byte id = 0;
          cmd.Parameters.AddWithValue("CreatedId", id);
          cmd.Parameters["CreatedId"].Direction = ParameterDirection.Output;

          cmd.ExecuteNonQuery();
        }

        conn.Close();
      }

      // Force refresh on the associated list
      if (_listBankAccounts != null)
      {
        _listBankAccounts.Clear();
        _listBankAccounts = null;
      }
    }

    public static void AddBank_New(DateTime date, byte idType, byte idAccount, decimal amount, string details)
    {
      //TODO: validate input

      using (SqlConnection conn = new SqlConnection(CommonDL.ConnectionString))
      {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "uspBankAdd_New";

          cmd.Parameters.AddWithValue(BankDL.Date, date);
          cmd.Parameters.AddWithValue(BankDL.IdType, idType);
          cmd.Parameters.AddWithValue(BankDL.IdAccount, idAccount);
          cmd.Parameters.AddWithValue(BankDL.Amount, amount);
          cmd.Parameters.AddWithValue(BankDL.Details, details);
          cmd.Parameters.Add("IdNewEntry", SqlDbType.Int);
          cmd.Parameters["IdNewEntry"].Direction = ParameterDirection.Output;

          cmd.ExecuteNonQuery();
        }

        conn.Close();
      }
    }

  }
}
