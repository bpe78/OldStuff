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
  public partial class FormIncomeAdd2 : Form
  {
    public FormIncomeAdd2()
    {
      InitializeComponent();
    }

    private void FormIncomeAdd_Load(object sender, EventArgs e)
    {
      DataTable dt = new DataTable("Income");
      dt.Columns.Add("Date", typeof(DateTime));
      dt.Columns.Add("Id_Category", typeof(short));
      dt.Columns.Add("Amount", typeof(decimal));
      dt.Columns.Add("Details", typeof(string));
      dt.Columns.Add("Id_Currency", typeof(byte));
      dt.Columns.Add("UseBankAccount", typeof(bool));
      dt.Columns.Add("Id_BankAccount", typeof(int));

      bindingSource1.DataSource = dt;
      dgvItems.DataSource = bindingSource1;
      dt.Rows.Add(dt.NewRow());

      // 
      // Date
      // 
      dgvItems.Columns["Date"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dgvItems.Columns["Date"].FillWeight = 10F;
      dgvItems.Columns["Date"].HeaderText = "Date";
      dgvItems.Columns["Date"].ReadOnly = false;
      // 
      // Category
      // 
      dgvItems.Columns["Id_Category"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dgvItems.Columns["Id_Category"].FillWeight = 18F;
      dgvItems.Columns["Id_Category"].HeaderText = "Category";
      dgvItems.Columns["Id_Category"].ReadOnly = true;
      // 
      // Amount
      // 
      dgvItems.Columns["Amount"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dgvItems.Columns["Amount"].FillWeight = 12F;
      dgvItems.Columns["Amount"].HeaderText = "Amount";
      dgvItems.Columns["Amount"].ReadOnly = true;
      // 
      // Details
      // 
      dgvItems.Columns["Details"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dgvItems.Columns["Details"].FillWeight = 30F;
      dgvItems.Columns["Details"].HeaderText = "Details";
      dgvItems.Columns["Details"].ReadOnly = true;
      // 
      // Account
      // 
      dgvItems.Columns["UseBankAccount"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dgvItems.Columns["UseBankAccount"].FillWeight = 10F;
      dgvItems.Columns["UseBankAccount"].HeaderText = "Use Bank Account";
      dgvItems.Columns["UseBankAccount"].ReadOnly = true;
      // 
      // Name
      // 
      dgvItems.Columns["Id_BankAccount"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dgvItems.Columns["Id_BankAccount"].FillWeight = 20F;
      dgvItems.Columns["Id_BankAccount"].HeaderText = "Account";
      dgvItems.Columns["Id_BankAccount"].ReadOnly = true;




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
