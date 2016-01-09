namespace BugetTest1
{
  partial class FormBankAddAccount
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
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.txtDescription = new System.Windows.Forms.TextBox();
      this.txtIBAN = new System.Windows.Forms.TextBox();
      this.cbBank = new System.Windows.Forms.ComboBox();
      this.cbCurrency = new System.Windows.Forms.ComboBox();
      this.chkInvestment = new System.Windows.Forms.CheckBox();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name :";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(66, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Description :";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 67);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(56, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Id (IBAN) :";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 93);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(38, 13);
      this.label4.TabIndex = 3;
      this.label4.Text = "Bank :";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 120);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(55, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "Currency :";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(94, 12);
      this.txtName.MaxLength = 25;
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(238, 20);
      this.txtName.TabIndex = 5;
      this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
      // 
      // txtDescription
      // 
      this.txtDescription.Enabled = false;
      this.txtDescription.Location = new System.Drawing.Point(94, 38);
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.Size = new System.Drawing.Size(238, 20);
      this.txtDescription.TabIndex = 6;
      // 
      // txtIBAN
      // 
      this.txtIBAN.Enabled = false;
      this.txtIBAN.Location = new System.Drawing.Point(94, 64);
      this.txtIBAN.MaxLength = 24;
      this.txtIBAN.Name = "txtIBAN";
      this.txtIBAN.Size = new System.Drawing.Size(238, 20);
      this.txtIBAN.TabIndex = 7;
      // 
      // cbBank
      // 
      this.cbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbBank.Enabled = false;
      this.cbBank.FormattingEnabled = true;
      this.cbBank.Location = new System.Drawing.Point(94, 90);
      this.cbBank.Name = "cbBank";
      this.cbBank.Size = new System.Drawing.Size(238, 21);
      this.cbBank.TabIndex = 8;
      // 
      // cbCurrency
      // 
      this.cbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbCurrency.Enabled = false;
      this.cbCurrency.FormattingEnabled = true;
      this.cbCurrency.Location = new System.Drawing.Point(94, 117);
      this.cbCurrency.Name = "cbCurrency";
      this.cbCurrency.Size = new System.Drawing.Size(238, 21);
      this.cbCurrency.TabIndex = 9;
      // 
      // chkInvestment
      // 
      this.chkInvestment.AutoSize = true;
      this.chkInvestment.Enabled = false;
      this.chkInvestment.Location = new System.Drawing.Point(94, 144);
      this.chkInvestment.Name = "chkInvestment";
      this.chkInvestment.Size = new System.Drawing.Size(120, 17);
      this.chkInvestment.TabIndex = 10;
      this.chkInvestment.Text = "Investment account";
      this.chkInvestment.UseVisualStyleBackColor = true;
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAdd.Enabled = false;
      this.btnAdd.Location = new System.Drawing.Point(94, 189);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 23);
      this.btnAdd.TabIndex = 11;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.Location = new System.Drawing.Point(175, 189);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 12;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // FormBankAddAccount
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(344, 224);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.txtDescription);
      this.Controls.Add(this.txtIBAN);
      this.Controls.Add(this.cbBank);
      this.Controls.Add(this.cbCurrency);
      this.Controls.Add(this.chkInvestment);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.btnClose);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormBankAddAccount";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add new bank account";
      this.Load += new System.EventHandler(this.FormBankAddAccount_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.TextBox txtIBAN;
    private System.Windows.Forms.ComboBox cbBank;
    private System.Windows.Forms.ComboBox cbCurrency;
    private System.Windows.Forms.CheckBox chkInvestment;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnClose;
  }
}