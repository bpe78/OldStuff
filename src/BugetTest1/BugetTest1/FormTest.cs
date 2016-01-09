using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BugetTest1.IncomeForms;
using BugetTest1.ExpenseForms;

namespace BugetTest1
{
  public partial class FormTest : Form
  {
    public FormTest()
    {
      InitializeComponent();
    }

    private void btnIncomeAdd_Click(object sender, EventArgs e)
    {
      FormIncomeAdd1 form = new FormIncomeAdd1();
      form.ShowDialog();
    }

    private void btnAddIncomeType_Click(object sender, EventArgs e)
    {
      FormIncomeAddType form = new FormIncomeAddType();
      form.ShowDialog();
    }

    private void btnAddExpense_Click(object sender, EventArgs e)
    {
      FormExpenseAdd form = new FormExpenseAdd();
      form.ShowDialog();
    }

    private void btnAddExpenseType_Click(object sender, EventArgs e)
    {
      FormExpenseAddType form = new FormExpenseAddType();
      form.ShowDialog();
    }

    private void btnBankAdd_Click(object sender, EventArgs e)
    {
      FormBankAdd form = new FormBankAdd();
      form.ShowDialog();
    }

    private void btnBankAccountAdd_Click(object sender, EventArgs e)
    {
      FormBankAddAccount form = new FormBankAddAccount();
      form.ShowDialog();
    }

    private void btnCalculate_Click(object sender, EventArgs e)
    {
      txtIncome.Text = Buget_BusinessLayer.IncomeBL.GetTotal(dtStarting.Value, dtEnding.Value, 1).ToString();
      //txtExpense.Text = Buget_BusinessLayer.ExpenseBL.GetExpense(dtStarting.Value, dtEnding.Value, 1).ToString();
    }
  }
}
