namespace BugetTest1
{
  partial class FormBankAdd
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
      this.dtDate = new System.Windows.Forms.DateTimePicker();
      this.cbType = new System.Windows.Forms.ComboBox();
      this.cbBankAccount = new System.Windows.Forms.ComboBox();
      this.txtAmount = new System.Windows.Forms.TextBox();
      this.txtDetails = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.cbCurrency = new System.Windows.Forms.ComboBox();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // dtDate
      // 
      this.dtDate.Location = new System.Drawing.Point(72, 12);
      this.dtDate.Name = "dtDate";
      this.dtDate.Size = new System.Drawing.Size(210, 20);
      this.dtDate.TabIndex = 5;
      // 
      // cbType
      // 
      this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbType.FormattingEnabled = true;
      this.cbType.Location = new System.Drawing.Point(74, 38);
      this.cbType.Name = "cbType";
      this.cbType.Size = new System.Drawing.Size(208, 21);
      this.cbType.TabIndex = 6;
      // 
      // cbBankAccount
      // 
      this.cbBankAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbBankAccount.FormattingEnabled = true;
      this.cbBankAccount.Location = new System.Drawing.Point(72, 65);
      this.cbBankAccount.Name = "cbBankAccount";
      this.cbBankAccount.Size = new System.Drawing.Size(210, 21);
      this.cbBankAccount.TabIndex = 7;
      this.cbBankAccount.SelectedIndexChanged += new System.EventHandler(this.cbBankAccount_SelectedIndexChanged);
      // 
      // txtAmount
      // 
      this.txtAmount.Location = new System.Drawing.Point(72, 92);
      this.txtAmount.Name = "txtAmount";
      this.txtAmount.Size = new System.Drawing.Size(124, 20);
      this.txtAmount.TabIndex = 8;
      this.txtAmount.Text = "0.00";
      this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // txtDetails
      // 
      this.txtDetails.Location = new System.Drawing.Point(74, 118);
      this.txtDetails.MaxLength = 50;
      this.txtDetails.Name = "txtDetails";
      this.txtDetails.Size = new System.Drawing.Size(208, 20);
      this.txtDetails.TabIndex = 10;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(36, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Date :";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Category :";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 68);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(53, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Account :";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 95);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(49, 13);
      this.label4.TabIndex = 3;
      this.label4.Text = "Amount :";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(12, 121);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(45, 13);
      this.label6.TabIndex = 4;
      this.label6.Text = "Details :";
      // 
      // cbCurrency
      // 
      this.cbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbCurrency.Enabled = false;
      this.cbCurrency.FormattingEnabled = true;
      this.cbCurrency.Location = new System.Drawing.Point(202, 91);
      this.cbCurrency.Name = "cbCurrency";
      this.cbCurrency.Size = new System.Drawing.Size(80, 21);
      this.cbCurrency.TabIndex = 9;
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAdd.Location = new System.Drawing.Point(64, 149);
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
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnClose.Location = new System.Drawing.Point(145, 149);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 12;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // FormBankAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnClose;
      this.ClientSize = new System.Drawing.Size(294, 184);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.cbCurrency);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtDetails);
      this.Controls.Add(this.txtAmount);
      this.Controls.Add(this.cbBankAccount);
      this.Controls.Add(this.cbType);
      this.Controls.Add(this.dtDate);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormBankAdd";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "FormBankAdd";
      this.Load += new System.EventHandler(this.FormBankAdd_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DateTimePicker dtDate;
    private System.Windows.Forms.ComboBox cbType;
    private System.Windows.Forms.ComboBox cbBankAccount;
    private System.Windows.Forms.TextBox txtAmount;
    private System.Windows.Forms.TextBox txtDetails;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox cbCurrency;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnClose;
  }
}