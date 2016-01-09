using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buget_DataLayer
{
  public static class BankAccountsDL
  {
    private static string _tableName = "BankAccounts";
    private static string _id = "ID";
    private static string _name = "Name";
    private static string _description = "Description";
    private static string _IBAN = "IBAN";
    private static string _issuer = "Id_Issuer";
    private static string _currency = "Id_Currency";
    private static string _investmentAccount = "InvestmentAccount";

    public static string TableName
    {
      get { return _tableName; }
    }

    public static string ID
    {
      get { return _id; }
    }

    public static string Name
    {
      get { return _name; }
    }

    public static string Description
    {
      get { return _description; }
    }

    public static string IBAN
    {
      get { return _IBAN; }
    }

    public static string Issuer
    {
      get { return _issuer; }
    }

    public static string Currency
    {
      get { return _currency; }
    }

    public static string InvestmentAccount
    {
      get { return _investmentAccount; }
    }
  }
}
