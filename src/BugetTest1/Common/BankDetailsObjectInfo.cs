using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  public class BankDetailsObjectInfo
  {
    #region Members & Properties

    private byte _id;
    private string _name;
    private string _city;

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

    public string City
    {
      get { return _city; }
      set { _city = value; }
    }

    #endregion

    public BankDetailsObjectInfo(byte id, string name, string city)
    {
      _id = id;
      _name = name;
      _city = city;
    }
  }
}
