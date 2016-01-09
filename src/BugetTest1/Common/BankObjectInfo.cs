using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  public class BankObjectInfo
  {
    #region Members & Properties

    private int _id;
    private string _description;

    public int ID
    {
      get { return _id; }
      set { _id = value; }
    }

    public string Description
    {
      get { return _description; }
      set { _description = value; }
    }

    #endregion

    public BankObjectInfo(int id, string description)
    {
      _id = id;
      _description = description;
    }
  }
}
