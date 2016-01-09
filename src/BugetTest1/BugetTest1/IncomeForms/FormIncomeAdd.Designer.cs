namespace BugetTest1.IncomeForms
{
  partial class FormIncomeAdd
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
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.dtDate = new System.Windows.Forms.DateTimePicker();
      this.cbType = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.txtAmount = new System.Windows.Forms.TextBox();
      this.txtDetails = new System.Windows.Forms.TextBox();
      this.cbCurrency = new System.Windows.Forms.ComboBox();
      this.radioCash = new System.Windows.Forms.RadioButton();
      this.radioAccount = new System.Windows.Forms.RadioButton();
      this.SuspendLayout();
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAdd.Enabled = false;
      this.btnAdd.Location = new System.Drawing.Point(69, 151);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 23);
      this.btnAdd.TabIndex = 0;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.Location = new System.Drawing.Point(150, 151);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 1;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(36, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Date :";
      // 
      // dtDate
      // 
      this.dtDate.Location = new System.Drawing.Point(75, 12);
      this.dtDate.Name = "dtDate";
      this.dtDate.Size = new System.Drawing.Size(207, 20);
      this.dtDate.TabIndex = 3;
      // 
      // cbType
      // 
      this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbType.FormattingEnabled = true;
      this.cbType.Location = new System.Drawing.Point(75, 38);
      this.cbType.Name = "cbType";
      this.cbType.Size = new System.Drawing.Size(207, 21);
      this.cbType.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Category :";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 68);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(49, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Amount :";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 94);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(45, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Details :";
      // 
      // txtAmount
      // 
      this.txtAmount.Location = new System.Drawing.Point(75, 65);
      this.txtAmount.MaxLength = 10;
      this.txtAmount.Name = "txtAmount";
      this.txtAmount.Size = new System.Drawing.Size(123, 20);
      this.txtAmount.TabIndex = 8;
      this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
      // 
      // txtDetails
      // 
      this.txtDetails.Location = new System.Drawing.Point(75, 91);
      this.txtDetails.Name = "txtDetails";
      this.txtDetails.Size = new System.Drawing.Size(207, 20);
      this.txtDetails.TabIndex = 9;
      // 
      // cbCurrency
      // 
      this.cbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbCurrency.FormattingEnabled = true;
      this.cbCurrency.Location = new System.Drawing.Point(204, 65);
      this.cbCurrency.Name = "cbCurrency";
      this.cbCurrency.Size = new System.Drawing.Size(78, 21);
      this.cbCurrency.TabIndex = 10;
      // 
      // radioCash
      // 
      this.radioCash.AutoSize = true;
      this.radioCash.Checked = true;
      this.radioCash.Enabled = false;
      this.radioCash.Location = new System.Drawing.Point(70, 117);
      this.radioCash.Name = "radioCash";
      this.radioCash.Size = new System.Drawing.Size(49, 17);
      this.radioCash.TabIndex = 11;
      this.radioCash.TabStop = true;
      this.radioCash.Text = "Cash";
      this.radioCash.UseVisualStyleBackColor = true;
      // 
      // radioAccount
      // 
      this.radioAccount.AutoSize = true;
      this.radioAccount.Enabled = false;
      this.radioAccount.Location = new System.Drawing.Point(139, 117);
      this.radioAccount.Name = "radioAccount";
      this.radioAccount.Size = new System.Drawing.Size(85, 17);
      this.radioAccount.TabIndex = 12;
      this.radioAccount.Text = "Into account";
      this.radioAccount.UseVisualStyleBackColor = true;
      // 
      // FormIncomeAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(294, 186);
      this.Controls.Add(this.radioAccount);
      this.Controls.Add(this.radioCash);
      this.Controls.Add(this.cbCurrency);
      this.Controls.Add(this.txtDetails);
      this.Controls.Add(this.txtAmount);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cbType);
      this.Controls.Add(this.dtDate);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnAdd);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormIncomeAdd";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add income";
      this.Load += new System.EventHandler(this.FormIncomeAdd_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dtDate;
    private System.Windows.Forms.ComboBox cbType;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtAmount;
    private System.Windows.Forms.TextBox txtDetails;
    private System.Windows.Forms.ComboBox cbCurrency;
    private System.Windows.Forms.RadioButton radioCash;
    private System.Windows.Forms.RadioButton radioAccount;
  }
}