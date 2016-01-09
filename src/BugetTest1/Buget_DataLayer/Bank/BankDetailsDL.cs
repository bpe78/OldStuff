using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buget_DataLayer
{
  public static class BankDetailsDL
  {
    private static string _tableName = "BankDetails";
    private static string _id = "ID";
    private static string _name = "Name";
    private static string _city = "City";

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

    public static string City
    {
      get { return _city; }
    }
  }
}
