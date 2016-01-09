using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buget_DataLayer
{
  public static class CurrencyDL
  {
    private static string _tableName = "_Currencies";
    private static string _id = "ID";
    private static string _name = "Symbol";

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
  }
}
