using System;

namespace Common
{
  public class ExpenseObjectInfo
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

    public ExpenseObjectInfo(int id, string description)
    {
      _id = id;
      _description = description;
    }
  }
}
