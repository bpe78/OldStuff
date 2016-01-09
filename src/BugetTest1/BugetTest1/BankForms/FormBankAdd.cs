using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buget_BusinessLayer;
using Common;

namespace BugetTest1
{
  public partial class FormBankAdd : Form
  {
    List<BankTypesObjectInfo> _listCategories;
    List<BankAccountsObjectInfo> _listAccounts;
    List<CurrencyObjectInfo> _listCurrencies;

    public FormBankAdd()
    {
      InitializeComponent();
    }

    private void FormBankAdd_Load(object sender, EventArgs e)
    {
      _listCategories = BankBL.GetBankTypesList();

      if (_listCategories != null)
      {
        cbType.DataSource = _listCategories;
        cbType.DisplayMember = "Name";
        cbType.ValueMember = "ID";
      }

      _listAccounts = BankBL.GetAccountsList();

      if (_listAccounts != null)
      {
        cbBankAccount.DataSource = _listAccounts;
        cbBankAccount.DisplayMember = "Name";
        cbBankAccount.ValueMember = "ID";
      }

      _listCurrencies = CurrencyBL.GetCurrencyList();

      if (_listCurrencies != null)
      {
        cbCurrency.DataSource = _listCurrencies;
        cbCurrency.DisplayMember = "Name";
        cbCurrency.ValueMember = "ID";
      }
    }

    private void cbBankAccount_SelectedIndexChanged(object sender, EventArgs e)
    {
      cbCurrency.SelectedValue = _listAccounts[cbBankAccount.SelectedIndex].Currency;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      byte idType = byte.Parse(cbType.SelectedValue.ToString());
      byte idAccount = byte.Parse(cbBankAccount.SelectedValue.ToString());
      decimal amount = decimal.Parse(txtAmount.Text);
     
      BankBL.AddBank_New(dtDate.Value, idType, idAccount, amount, txtDetails.Text);

    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
