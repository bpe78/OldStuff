using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  public class CurrencyObjectInfo
  {
    #region Members & Properties

    private byte _id;
    private string _name;

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

    #endregion

    public CurrencyObjectInfo(byte id, string name)
    {
      _id = id;
      _name = name;
    }
  }
}
