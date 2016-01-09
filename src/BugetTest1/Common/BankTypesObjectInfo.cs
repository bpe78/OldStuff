using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  public class BankTypesObjectInfo
  {
    #region Members & Properties

    private byte _id;
    private string _name;
    private bool _income;

    public byte ID
    {
      get { return _id; }
      set { _id = value; }
    }

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public bool Income
    {
      get { return _income; }
      set { _income = value; }
    }

    #endregion

    public BankTypesObjectInfo(byte id, string name, bool income)
    {
      _id = id;
      _name = name;
      _income = income;
    }
  }
}
