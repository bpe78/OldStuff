using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buget_DataLayer
{
  public static class BankDL
  {
    private static string _tableName = "Bank";
    private static string _id = "ID";
    private static string _date = "Date";
    private static string _idType = "Id_Type";
    private static string _idAccount = "Id_Account";
    private static string _amount = "Amount";
    private static string _taxes = "Taxes";
    private static string _details = "Details";

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

    public static string IdAccount
    {
      get { return _idAccount; }
    }

    public static string Amount
    {
      get { return _amount; }
    }

    public static string Taxes
    {
      get { return _taxes; }
    }

    public static string Details
    {
      get { return _details; }
    }
  }
}
