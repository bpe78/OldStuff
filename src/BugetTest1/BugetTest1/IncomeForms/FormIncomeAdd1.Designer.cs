namespace BugetTest1.IncomeForms
{
  partial class FormIncomeAdd1
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cbAccountName = new System.Windows.Forms.ComboBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.cbAccountCurrency = new System.Windows.Forms.ComboBox();
      this.label8 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAdd.Enabled = false;
      this.btnAdd.Location = new System.Drawing.Point(69, 275);
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
      this.btnClose.Location = new System.Drawing.Point(150, 275);
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
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label8);
      this.groupBox1.Controls.Add(this.cbAccountCurrency);
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.textBox2);
      this.groupBox1.Controls.Add(this.textBox1);
      this.groupBox1.Controls.Add(this.cbAccountName);
      this.groupBox1.Location = new System.Drawing.Point(12, 140);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(270, 129);
      this.groupBox1.TabIndex = 13;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Account info";
      // 
      // cbAccountName
      // 
      this.cbAccountName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbAccountName.Enabled = false;
      this.cbAccountName.FormattingEnabled = true;
      this.cbAccountName.Location = new System.Drawing.Point(63, 19);
      this.cbAccountName.Name = "cbAccountName";
      this.cbAccountName.Size = new System.Drawing.Size(201, 21);
      this.cbAccountName.TabIndex = 14;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(63, 46);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new System.Drawing.Size(201, 20);
      this.textBox1.TabIndex = 15;
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(63, 72);
      this.textBox2.Name = "textBox2";
      this.textBox2.ReadOnly = true;
      this.textBox2.Size = new System.Drawing.Size(201, 20);
      this.textBox2.TabIndex = 16;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 22);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 13);
      this.label5.TabIndex = 17;
      this.label5.Text = "Name :";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 49);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(45, 13);
      this.label6.TabIndex = 18;
      this.label6.Text = "Details :";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 75);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(38, 13);
      this.label7.TabIndex = 19;
      this.label7.Text = "Bank :";
      // 
      // cbAccountCurrency
      // 
      this.cbAccountCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbAccountCurrency.Enabled = false;
      this.cbAccountCurrency.FormattingEnabled = true;
      this.cbAccountCurrency.Location = new System.Drawing.Point(65, 98);
      this.cbAccountCurrency.Name = "cbAccountCurrency";
      this.cbAccountCurrency.Size = new System.Drawing.Size(78, 21);
      this.cbAccountCurrency.TabIndex = 20;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(6, 101);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(55, 13);
      this.label8.TabIndex = 21;
      this.label8.Text = "Currency :";
      // 
      // FormIncomeAdd1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(294, 310);
      this.Controls.Add(this.groupBox1);
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
      this.Name = "FormIncomeAdd1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add income";
      this.Load += new System.EventHandler(this.FormIncomeAdd_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
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
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ComboBox cbAccountName;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.ComboBox cbAccountCurrency;
    private System.Windows.Forms.Label label8;
  }
}