using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buget_DataLayer
{
  public static class BankTypesDL
  {
    private static string _tableName = "BankTypes";
    private static string _id = "ID";
    private static string _name = "Name";
    private static string _income = "Income";

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

    public static string Income
    {
      get { return _income; }
    }
  }
}
