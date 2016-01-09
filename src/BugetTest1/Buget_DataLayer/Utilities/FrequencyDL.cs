using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buget_DataLayer
{
  public static class FrequencyDL
  {
    private static string _tableName = "_Frequencies";
    private static string _id = "ID";
    private static string _name = "Name";
    //private static string _description = "Description";
    //private static string _hasCounter = "HasCounter";
    //private static string _daily = "Daily";
    //private static string _weekly = "Weekly";
    //private static string _monthly = "Monthly";
    //private static string _yearly = "Yearly";

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
