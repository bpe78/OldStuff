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
  public partial class FormBankAddAccount : Form
  {
    public FormBankAddAccount()
    {
      InitializeComponent();
    }

    private void FormBankAddAccount_Load(object sender, EventArgs e)
    {
      List<BankDetailsObjectInfo> listBanks = BankBL.GetBankDetailsList();

      if (listBanks != null)
      {
        cbBank.DataSource = listBanks;
        cbBank.DisplayMember = "Name";
        cbBank.ValueMember = "ID";
      }

      List<CurrencyObjectInfo> listCurrencies = CurrencyBL.GetCurrencyList();

      if (listCurrencies != null)
      {
        cbCurrency.DataSource = listCurrencies;
        cbCurrency.DisplayMember = "Name";
        cbCurrency.ValueMember = "ID";
      }
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
      bool enableControls = txtName.Text.Length > 0;
      txtDescription.Enabled = enableControls;
      txtIBAN.Enabled = enableControls;
      cbBank.Enabled = enableControls;
      cbCurrency.Enabled = enableControls;
      chkInvestment.Enabled = enableControls;
      btnAdd.Enabled = enableControls;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      //TODO: validate and save information

      byte idBank = 0;
      if (!byte.TryParse(cbBank.SelectedValue.ToString(), out idBank))
        idBank = 0;
      byte idCurrency;
      if(!byte.TryParse(cbCurrency.SelectedValue.ToString(), out idCurrency))
        idCurrency = 0;
      Buget_BusinessLayer.BankBL.AddBankAccount(txtName.Text, txtDescription.Text, txtIBAN.Text, idBank, idCurrency, chkInvestment.Checked);

      Reset();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void Reset()
    {
      txtName.Text = string.Empty;
      txtDescription.Text = string.Empty;
      txtIBAN.Text = string.Empty;
      chkInvestment.Checked = false;

      MessageBox.Show("Added", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
      txtName.Focus();
    }
  }
}
