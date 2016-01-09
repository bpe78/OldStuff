namespace BugetTest1
{
  partial class FormIncomeAddType
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.txtDescription = new System.Windows.Forms.TextBox();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cbAccount = new System.Windows.Forms.ComboBox();
      this.radioAccount = new System.Windows.Forms.RadioButton();
      this.radioCash = new System.Windows.Forms.RadioButton();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.txtFrequencyCounter = new System.Windows.Forms.TextBox();
      this.chkEnding = new System.Windows.Forms.CheckBox();
      this.label2 = new System.Windows.Forms.Label();
      this.dtEndDate = new System.Windows.Forms.DateTimePicker();
      this.dtStartDate = new System.Windows.Forms.DateTimePicker();
      this.cbFrequency = new System.Windows.Forms.ComboBox();
      this.radioRegular = new System.Windows.Forms.RadioButton();
      this.radioNotRegular = new System.Windows.Forms.RadioButton();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(69, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Description : ";
      // 
      // txtDescription
      // 
      this.txtDescription.Location = new System.Drawing.Point(87, 12);
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.Size = new System.Drawing.Size(245, 20);
      this.txtDescription.TabIndex = 1;
      this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAdd.Location = new System.Drawing.Point(94, 250);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 23);
      this.btnAdd.TabIndex = 2;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.Location = new System.Drawing.Point(175, 250);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.cbAccount);
      this.groupBox1.Controls.Add(this.radioAccount);
      this.groupBox1.Controls.Add(this.radioCash);
      this.groupBox1.Location = new System.Drawing.Point(12, 38);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(320, 72);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Collect as";
      // 
      // cbAccount
      // 
      this.cbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbAccount.Enabled = false;
      this.cbAccount.FormattingEnabled = true;
      this.cbAccount.Location = new System.Drawing.Point(106, 41);
      this.cbAccount.Name = "cbAccount";
      this.cbAccount.Size = new System.Drawing.Size(208, 21);
      this.cbAccount.TabIndex = 2;
      // 
      // radioAccount
      // 
      this.radioAccount.AutoSize = true;
      this.radioAccount.Location = new System.Drawing.Point(6, 42);
      this.radioAccount.Name = "radioAccount";
      this.radioAccount.Size = new System.Drawing.Size(94, 17);
      this.radioAccount.TabIndex = 1;
      this.radioAccount.TabStop = true;
      this.radioAccount.Text = "Into account : ";
      this.radioAccount.UseVisualStyleBackColor = true;
      this.radioAccount.CheckedChanged += new System.EventHandler(this.Collect_CheckedChanged);
      // 
      // radioCash
      // 
      this.radioCash.AutoSize = true;
      this.radioCash.Location = new System.Drawing.Point(6, 19);
      this.radioCash.Name = "radioCash";
      this.radioCash.Size = new System.Drawing.Size(49, 17);
      this.radioCash.TabIndex = 0;
      this.radioCash.TabStop = true;
      this.radioCash.Text = "Cash";
      this.radioCash.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.txtFrequencyCounter);
      this.groupBox2.Controls.Add(this.chkEnding);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.dtEndDate);
      this.groupBox2.Controls.Add(this.dtStartDate);
      this.groupBox2.Controls.Add(this.cbFrequency);
      this.groupBox2.Controls.Add(this.radioRegular);
      this.groupBox2.Controls.Add(this.radioNotRegular);
      this.groupBox2.Location = new System.Drawing.Point(12, 116);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(320, 124);
      this.groupBox2.TabIndex = 5;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Frequency of payment";
      // 
      // txtFrequencyCounter
      // 
      this.txtFrequencyCounter.Location = new System.Drawing.Point(90, 42);
      this.txtFrequencyCounter.Name = "txtFrequencyCounter";
      this.txtFrequencyCounter.Size = new System.Drawing.Size(28, 20);
      this.txtFrequencyCounter.TabIndex = 8;
      // 
      // chkEnding
      // 
      this.chkEnding.AutoSize = true;
      this.chkEnding.Location = new System.Drawing.Point(43, 94);
      this.chkEnding.Name = "chkEnding";
      this.chkEnding.Size = new System.Drawing.Size(65, 17);
      this.chkEnding.TabIndex = 7;
      this.chkEnding.Text = "Ending :";
      this.chkEnding.UseVisualStyleBackColor = true;
      this.chkEnding.CheckedChanged += new System.EventHandler(this.chkEnding_CheckedChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(40, 74);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(49, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Starting :";
      // 
      // dtEndDate
      // 
      this.dtEndDate.Location = new System.Drawing.Point(124, 94);
      this.dtEndDate.Name = "dtEndDate";
      this.dtEndDate.Size = new System.Drawing.Size(189, 20);
      this.dtEndDate.TabIndex = 5;
      // 
      // dtStartDate
      // 
      this.dtStartDate.Location = new System.Drawing.Point(125, 68);
      this.dtStartDate.Name = "dtStartDate";
      this.dtStartDate.Size = new System.Drawing.Size(189, 20);
      this.dtStartDate.TabIndex = 4;
      // 
      // cbFrequency
      // 
      this.cbFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbFrequency.Enabled = false;
      this.cbFrequency.FormattingEnabled = true;
      this.cbFrequency.Location = new System.Drawing.Point(124, 41);
      this.cbFrequency.Name = "cbFrequency";
      this.cbFrequency.Size = new System.Drawing.Size(190, 21);
      this.cbFrequency.TabIndex = 2;
      this.cbFrequency.EnabledChanged += new System.EventHandler(this.cbFrequency_EnabledChanged);
      this.cbFrequency.SelectedIndexChanged += new System.EventHandler(this.cbFrequency_SelectedIndexChanged);
      // 
      // radioRegular
      // 
      this.radioRegular.AutoSize = true;
      this.radioRegular.Location = new System.Drawing.Point(6, 42);
      this.radioRegular.Name = "radioRegular";
      this.radioRegular.Size = new System.Drawing.Size(69, 17);
      this.radioRegular.TabIndex = 1;
      this.radioRegular.TabStop = true;
      this.radioRegular.Text = "Regularly";
      this.radioRegular.UseVisualStyleBackColor = true;
      this.radioRegular.CheckedChanged += new System.EventHandler(this.Frequency_CheckedChanged);
      // 
      // radioNotRegular
      // 
      this.radioNotRegular.AutoSize = true;
      this.radioNotRegular.Location = new System.Drawing.Point(6, 19);
      this.radioNotRegular.Name = "radioNotRegular";
      this.radioNotRegular.Size = new System.Drawing.Size(69, 17);
      this.radioNotRegular.TabIndex = 0;
      this.radioNotRegular.TabStop = true;
      this.radioNotRegular.Text = "Irregulate";
      this.radioNotRegular.UseVisualStyleBackColor = true;
      this.radioNotRegular.CheckedChanged += new System.EventHandler(this.Frequency_CheckedChanged);
      // 
      // FormIncomeAddType
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(344, 285);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.txtDescription);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormIncomeAddType";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "FormIncomeAddType";
      this.Load += new System.EventHandler(this.FormIncomeAddType_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ComboBox cbAccount;
    private System.Windows.Forms.RadioButton radioAccount;
    private System.Windows.Forms.RadioButton radioCash;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.DateTimePicker dtStartDate;
    private System.Windows.Forms.ComboBox cbFrequency;
    private System.Windows.Forms.RadioButton radioRegular;
    private System.Windows.Forms.RadioButton radioNotRegular;
    private System.Windows.Forms.CheckBox chkEnding;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DateTimePicker dtEndDate;
    private System.Windows.Forms.TextBox txtFrequencyCounter;
  }
}