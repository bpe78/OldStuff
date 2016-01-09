using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buget_DataLayer
{
  public static class IncomeTypesDL
  {
    private static string _tableName = "IncomeTypes";
    private static string _id = "ID";
    private static string _name = "Name";
    private static string _useBankAccount = "UseBankAccount";
    private static string _idAccount = "Id_Account";
    private static string _isRegularPayment = "RegularPayment";
    private static string _frequency = "Frequency";
    private static string _frequencyCounter = "FrequencyCounter";
    private static string _startDate = "StartingDate";
    private static string _endDate = "EndingDate";


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

    public static string UseBankAccount
    {
      get { return _useBankAccount; }
    }

    public static string IdAccount
    {
      get { return _idAccount; }
    }

    public static string RegularPayment
    {
      get { return _isRegularPayment; }
    }

    public static string Frequency
    {
      get { return _frequency; }
    }
    public static string FrequencyCounter
    {
      get { return _frequencyCounter; }
    }

    public static string StartDate
    {
      get { return _startDate; }
    }

    public static string EndDate
    {
      get { return _endDate; }
    }
  }
}
