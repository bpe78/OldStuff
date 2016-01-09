using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using Buget_BusinessLayer;

namespace BugetTest1.IncomeForms
{
  public partial class FormIncomeAdd1 : Form
  {
    public FormIncomeAdd1()
    {
      InitializeComponent();
    }

    private void FormIncomeAdd_Load(object sender, EventArgs e)
    {
      radioCash.Checked = true;
      btnAdd.Enabled = false;

      List<IncomeTypesObjectInfo> listIncomeTypes = IncomeBL.GetIncomeTypesList();

      if (listIncomeTypes != null)
      {
        cbType.DataSource = listIncomeTypes;
        cbType.DisplayMember = "Name";
        cbType.ValueMember = "ID";
      }

      List<CurrencyObjectInfo> listCurrencies = CurrencyBL.GetCurrencyList();

      if (listCurrencies != null)
      {
        cbCurrency.DataSource = listCurrencies;
        cbCurrency.DisplayMember = "Name";
        cbCurrency.ValueMember = "ID";
      }

      radioCash.Enabled = radioAccount.Enabled = false;
      //TODO: activate controls only if there is a record in IncomeTypes for this category 
    }

    private void txtAmount_TextChanged(object sender, EventArgs e)
    {
      bool enableControls = (txtAmount.Text.Length > 0);
      radioCash.Enabled = enableControls;
      radioAccount.Enabled = enableControls;
      btnAdd.Enabled = enableControls;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      short idType = short.Parse(cbType.SelectedValue.ToString());
      decimal amount = decimal.Parse(txtAmount.Text);
      byte idCurrency = byte.Parse(cbCurrency.SelectedValue.ToString());
      IncomeBL.AddIncome_New(dtDate.Value, idType, amount, txtDetails.Text, idCurrency, radioAccount.Checked);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
