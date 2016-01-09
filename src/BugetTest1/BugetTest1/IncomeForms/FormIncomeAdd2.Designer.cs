namespace BugetTest1.IncomeForms
{
  partial class FormIncomeAdd2
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
      this.label8 = new System.Windows.Forms.Label();
      this.cbAccountCurrency = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.cbAccountName = new System.Windows.Forms.ComboBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.dgvItems = new System.Windows.Forms.DataGridView();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
      this.SuspendLayout();
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAdd.Enabled = false;
      this.btnAdd.Location = new System.Drawing.Point(378, 473);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 23);
      this.btnAdd.TabIndex = 0;
      this.btnAdd.Text = "Save";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.Location = new System.Drawing.Point(459, 473);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 1;
      this.btnClose.Text = "Exit";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(36, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Date :";
      // 
      // dtDate
      // 
      this.dtDate.Location = new System.Drawing.Point(89, 19);
      this.dtDate.Name = "dtDate";
      this.dtDate.Size = new System.Drawing.Size(207, 20);
      this.dtDate.TabIndex = 3;
      // 
      // cbType
      // 
      this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbType.FormattingEnabled = true;
      this.cbType.Location = new System.Drawing.Point(89, 45);
      this.cbType.Name = "cbType";
      this.cbType.Size = new System.Drawing.Size(207, 21);
      this.cbType.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 47);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Category :";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 74);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(49, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Amount :";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 100);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(45, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Details :";
      // 
      // txtAmount
      // 
      this.txtAmount.Location = new System.Drawing.Point(89, 72);
      this.txtAmount.MaxLength = 10;
      this.txtAmount.Name = "txtAmount";
      this.txtAmount.Size = new System.Drawing.Size(123, 20);
      this.txtAmount.TabIndex = 8;
      this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
      // 
      // txtDetails
      // 
      this.txtDetails.Location = new System.Drawing.Point(89, 98);
      this.txtDetails.Name = "txtDetails";
      this.txtDetails.Size = new System.Drawing.Size(207, 20);
      this.txtDetails.TabIndex = 9;
      // 
      // cbCurrency
      // 
      this.cbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbCurrency.FormattingEnabled = true;
      this.cbCurrency.Location = new System.Drawing.Point(218, 72);
      this.cbCurrency.Name = "cbCurrency";
      this.cbCurrency.Size = new System.Drawing.Size(78, 21);
      this.cbCurrency.TabIndex = 10;
      // 
      // radioCash
      // 
      this.radioCash.AutoSize = true;
      this.radioCash.Checked = true;
      this.radioCash.Enabled = false;
      this.radioCash.Location = new System.Drawing.Point(84, 124);
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
      this.radioAccount.Location = new System.Drawing.Point(153, 124);
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
      this.groupBox1.Location = new System.Drawing.Point(475, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(270, 150);
      this.groupBox1.TabIndex = 13;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Account info";
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
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 75);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(38, 13);
      this.label7.TabIndex = 19;
      this.label7.Text = "Bank :";
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
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 22);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 13);
      this.label5.TabIndex = 17;
      this.label5.Text = "Name :";
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(63, 72);
      this.textBox2.Name = "textBox2";
      this.textBox2.ReadOnly = true;
      this.textBox2.Size = new System.Drawing.Size(201, 20);
      this.textBox2.TabIndex = 16;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(63, 46);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new System.Drawing.Size(201, 20);
      this.textBox1.TabIndex = 15;
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
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.dtDate);
      this.groupBox2.Controls.Add(this.radioAccount);
      this.groupBox2.Controls.Add(this.cbType);
      this.groupBox2.Controls.Add(this.radioCash);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.cbCurrency);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.txtDetails);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.txtAmount);
      this.groupBox2.Location = new System.Drawing.Point(167, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(302, 150);
      this.groupBox2.TabIndex = 14;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Operation";
      // 
      // dgvItems
      // 
      this.dgvItems.AllowUserToAddRows = false;
      this.dgvItems.AllowUserToDeleteRows = false;
      this.dgvItems.AllowUserToResizeColumns = false;
      this.dgvItems.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvItems.Location = new System.Drawing.Point(12, 197);
      this.dgvItems.MultiSelect = false;
      this.dgvItems.Name = "dgvItems";
      this.dgvItems.RowHeadersVisible = false;
      this.dgvItems.Size = new System.Drawing.Size(889, 270);
      this.dgvItems.TabIndex = 15;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(378, 168);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 16;
      this.button1.Text = "Add";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.button2.Location = new System.Drawing.Point(459, 168);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 17;
      this.button2.Text = "Clear";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // FormIncomeAdd2
      // 
      this.AcceptButton = this.button1;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.button2;
      this.ClientSize = new System.Drawing.Size(913, 508);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.dgvItems);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnAdd);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormIncomeAdd2";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add income";
      this.Load += new System.EventHandler(this.FormIncomeAdd_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
      this.ResumeLayout(false);

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
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.DataGridView dgvItems;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.BindingSource bindingSource1;

  }
}