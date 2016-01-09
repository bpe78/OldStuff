using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using Buget_BusinessLayer;

namespace BugetTest1.ExpenseForms
{
  public partial class FormExpenseAddType : Form
  {
    public FormExpenseAddType()
    {
      InitializeComponent();
    }

    private void FormExpenseAddType_Load(object sender, EventArgs e)
    {
      radioCash.Checked = true;
      radioNotRegular.Checked = true;
      btnAdd.Enabled = false;

      List<BankAccountsObjectInfo> listAccounts = BankBL.GetAccountsList();

      if (listAccounts != null)
      {
        cbAccount.DataSource = listAccounts;
        cbAccount.DisplayMember = "Name";
        cbAccount.ValueMember = "ID";
      }

      List<FrequencyObjectInfo> listFrequencies = null;
      listFrequencies = FrequencyBL.GetFrequencyList();

      if (listFrequencies != null)
      {
        cbFrequency.DataSource = listFrequencies;
        cbFrequency.DisplayMember = "Name";
        cbFrequency.ValueMember = "ID";
      }
    }

    private void txtDescription_TextChanged(object sender, EventArgs e)
    {
      btnAdd.Enabled = (txtDescription.Text.Length > 0);
    }

    private void Collect_CheckedChanged(object sender, EventArgs e)
    {
      UpdateCollectOptions();
    }

    private void Frequency_CheckedChanged(object sender, EventArgs e)
    {
      UpdateFrequencyOptions();
    }

    private void cbFrequency_EnabledChanged(object sender, EventArgs e)
    {
      UpdateFrequencySelector();
    }

    private void cbFrequency_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateFrequencySelector();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      AddNewExpenseType();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    #region Helper Methods

    private void UpdateCollectOptions()
    {
      bool enableCollectControls = false;
      if (radioAccount.Checked)
        enableCollectControls = true;

      // update all related controls accordingly
      cbAccount.Enabled = enableCollectControls;
    }

    private void UpdateFrequencyOptions()
    {
      bool enableRegularControls = false;
      if (radioRegular.Checked)
        enableRegularControls = true;

      // update all related controls accordingly
      cbFrequency.Enabled = enableRegularControls;
      UpdateFrequencySelector();
    }

    private void UpdateFrequencySelector()
    {
      bool enableFrequencyControls = cbFrequency.Enabled;
      txtFrequencyCounter.Enabled = enableFrequencyControls && ((cbFrequency.SelectedIndex == 4) || (cbFrequency.SelectedIndex == 5));

      dtStartDate.Enabled = enableFrequencyControls;
      chkEnding.Enabled = enableFrequencyControls;
      UpdateEndDateControl();
    }

    #endregion

    private void chkEnding_CheckedChanged(object sender, EventArgs e)
    {
      UpdateEndDateControl();
    }

    private void UpdateEndDateControl()
    {
      dtEndDate.Enabled = chkEnding.Enabled && chkEnding.Checked;
    }

    private void AddNewExpenseType()
    {
      byte? idAccount = null;

      if (radioAccount.Checked)
        idAccount = byte.Parse(cbAccount.SelectedValue.ToString());

      byte? frequency = null;
      short? counterFrequency = null;
      DateTime? startDate = null;
      DateTime? endDate = null;
      if (radioRegular.Checked)
      {
        frequency = byte.Parse(cbFrequency.SelectedValue.ToString());
        if (txtFrequencyCounter.Text.Length > 0)
          counterFrequency = short.Parse(txtFrequencyCounter.Text);
        startDate = dtStartDate.Value;
        if (chkEnding.Checked)
          endDate = dtEndDate.Value;
      }

      ExpenseBL.AddExpenseType(txtDescription.Text, radioAccount.Checked, idAccount, radioRegular.Checked, frequency, counterFrequency, startDate, endDate);

      Reset();
    }

    private void Reset()
    {
      txtDescription.Text = string.Empty;
      radioCash.Checked = true;
      radioNotRegular.Checked = true;

      txtDescription.Focus();
    }
  }
}
