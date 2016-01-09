using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  public class FrequencyObjectInfo
  {
    #region Members & Properties

    private int _id;
    private string _name;

    public int ID
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

    public FrequencyObjectInfo(int id, string name)
    {
      _id = id;
      _name = name;
    }
  }
}
