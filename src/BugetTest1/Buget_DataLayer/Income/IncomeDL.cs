using System;
using System.Collections.Generic;
using System.Text;

namespace Buget_DataLayer
{
  public static class IncomeDL
  {
    private static string _tableName = "Income";
    private static string _id = "ID";
    private static string _date = "Date";
    private static string _idType = "Id_Type";
    private static string _amount = "Amount";
    private static string _details = "Details";
    private static string _idCurrency = "Id_Currency";
    private static string _useBankAccount = "UseBankAccount";
    private static string _idBankOp = "Id_BankOp";

    public static string TableName
    {
      get { return _tableName; }
    }

    public static string ID
    {
      get { return _id; }
    }

    public static string Date
    {
      get { return _date; }
    }

    public static string IdType
    {
      get { return _idType; }
    }

    public static string Amount
    {
      get { return _amount; }
    }

    public static string Details
    {
      get { return _details; }
    }

    public static string IdCurrency
    {
      get { return _idCurrency; }
      set { _idCurrency = value; }
    }

    public static string UseBankAccount
    {
      get { return _useBankAccount; }
      set { _useBankAccount = value; }
    }

    public static string IdBankOp
    {
      get { return _idBankOp; }
      set { _idBankOp = value; }
    }
  }
}
