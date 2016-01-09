using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  public class BankAccountsObjectInfo
  {
    #region Members & Properties

    private byte _id;
    private string _name;
    private string _description;
    private string _IBAN;
    private byte _issuer;
    private byte _currency;
    private bool _isInvestmentAccount;

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

    public string Description
    {
      get { return _description; }
      set { _description = value; }
    }

    public string IBAN
    {
      get { return _IBAN; }
      set { _IBAN = value; }
    }

    public byte Issuer
    {
      get { return _issuer; }
      set { _issuer = value; }
    }

    public byte Currency
    {
      get { return _currency; }
      set { _currency = value; }
    }

    public bool IsInvestmentAccount
    {
      get { return _isInvestmentAccount; }
      set { _isInvestmentAccount = value; }
    }

    #endregion

    public BankAccountsObjectInfo(byte id, string name, string description, string iban, byte issuer, byte currency, bool isInvestmentAccount)
    {
      _id = id;
      _name = name;
      _description = description;
      _IBAN = iban;
      _issuer = issuer;
      _currency = currency;
      _isInvestmentAccount = isInvestmentAccount;
    }
  }
}
