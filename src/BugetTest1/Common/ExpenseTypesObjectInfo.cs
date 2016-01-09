using System;

namespace Common
{
  public class ExpenseTypesObjectInfo
  {
    #region Members & Properties

    private short _id;
    private string _name;
    private bool _useBankAccount;
    private byte _idAccount;
    private bool _isRegularPayment;
    private byte _frequency;
    private short _frequencyCounter;
    private DateTime _startDate;
    private DateTime _endDate;

    public short ID
    {
      get { return _id; }
      set { _id = value; }
    }

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public bool UseBankAccount
    {
      get { return _useBankAccount; }
      set { _useBankAccount = value; }
    }

    public byte IdAccount
    {
      get { return _idAccount; }
      set { _idAccount = value; }
    }

    public bool IsRegularPayment
    {
      get { return _isRegularPayment; }
      set { _isRegularPayment = value; }
    }

    public byte Frequency
    {
      get { return _frequency; }
      set { _frequency = value; }
    }

    public short FrequencyCounter
    {
      get { return _frequencyCounter; }
      set { _frequencyCounter = value; }
    }

    public DateTime StartDate
    {
      get { return _startDate; }
      set { _startDate = value; }
    }

    public DateTime EndDate
    {
      get { return _endDate; }
      set { _endDate = value; }
    }

    #endregion

    public ExpenseTypesObjectInfo(short id, string name, bool useBankAccount, byte idAccount, bool isRegularPayment, byte frequency, short frequencyCounter, DateTime startDate, DateTime endDate)
    {
      _id = id;
      _name = name;
      _useBankAccount = useBankAccount;
      _idAccount = idAccount;
      _isRegularPayment = isRegularPayment;
      _frequency = frequency;
      _frequencyCounter = frequencyCounter;
      _startDate = startDate;
      _endDate = endDate;
    }
  }
}
