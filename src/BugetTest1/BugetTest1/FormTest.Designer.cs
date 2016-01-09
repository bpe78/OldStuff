namespace BugetTest1
{
  partial class FormTest
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
      this.btnAddIncomeType = new System.Windows.Forms.Button();
      this.btnAddBankAccount = new System.Windows.Forms.Button();
      this.btnAddIncome = new System.Windows.Forms.Button();
      this.btnAddBank = new System.Windows.Forms.Button();
      this.btnAddExpense = new System.Windows.Forms.Button();
      this.btnAddExpenseType = new System.Windows.Forms.Button();
      this.txtIncome = new System.Windows.Forms.TextBox();
      this.dtEnding = new System.Windows.Forms.DateTimePicker();
      this.dtStarting = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.txtExpense = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtSavings = new System.Windows.Forms.TextBox();
      this.btnCalculate = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnAddIncomeType
      // 
      this.btnAddIncomeType.Location = new System.Drawing.Point(12, 12);
      this.btnAddIncomeType.Name = "btnAddIncomeType";
      this.btnAddIncomeType.Size = new System.Drawing.Size(123, 23);
      this.btnAddIncomeType.TabIndex = 0;
      this.btnAddIncomeType.Text = "Add Income Type";
      this.btnAddIncomeType.UseVisualStyleBackColor = true;
      this.btnAddIncomeType.Click += new System.EventHandler(this.btnAddIncomeType_Click);
      // 
      // btnAddBankAccount
      // 
      this.btnAddBankAccount.Location = new System.Drawing.Point(271, 12);
      this.btnAddBankAccount.Name = "btnAddBankAccount";
      this.btnAddBankAccount.Size = new System.Drawing.Size(123, 23);
      this.btnAddBankAccount.TabIndex = 1;
      this.btnAddBankAccount.Text = "Add Bank Account";
      this.btnAddBankAccount.UseVisualStyleBackColor = true;
      this.btnAddBankAccount.Click += new System.EventHandler(this.btnBankAccountAdd_Click);
      // 
      // btnAddIncome
      // 
      this.btnAddIncome.Location = new System.Drawing.Point(12, 41);
      this.btnAddIncome.Name = "btnAddIncome";
      this.btnAddIncome.Size = new System.Drawing.Size(123, 23);
      this.btnAddIncome.TabIndex = 2;
      this.btnAddIncome.Text = "Add Income";
      this.btnAddIncome.UseVisualStyleBackColor = true;
      this.btnAddIncome.Click += new System.EventHandler(this.btnIncomeAdd_Click);
      // 
      // btnAddBank
      // 
      this.btnAddBank.Location = new System.Drawing.Point(271, 41);
      this.btnAddBank.Name = "btnAddBank";
      this.btnAddBank.Size = new System.Drawing.Size(123, 23);
      this.btnAddBank.TabIndex = 3;
      this.btnAddBank.Text = "Add Bank Record";
      this.btnAddBank.UseVisualStyleBackColor = true;
      this.btnAddBank.Click += new System.EventHandler(this.btnBankAdd_Click);
      // 
      // btnAddExpense
      // 
      this.btnAddExpense.Location = new System.Drawing.Point(141, 41);
      this.btnAddExpense.Name = "btnAddExpense";
      this.btnAddExpense.Size = new System.Drawing.Size(123, 23);
      this.btnAddExpense.TabIndex = 5;
      this.btnAddExpense.Text = "Add Expense";
      this.btnAddExpense.UseVisualStyleBackColor = true;
      this.btnAddExpense.Click += new System.EventHandler(this.btnAddExpense_Click);
      // 
      // btnAddExpenseType
      // 
      this.btnAddExpenseType.Location = new System.Drawing.Point(141, 12);
      this.btnAddExpenseType.Name = "btnAddExpenseType";
      this.btnAddExpenseType.Size = new System.Drawing.Size(123, 23);
      this.btnAddExpenseType.TabIndex = 4;
      this.btnAddExpenseType.Text = "Add Expense Type";
      this.btnAddExpenseType.UseVisualStyleBackColor = true;
      this.btnAddExpenseType.Click += new System.EventHandler(this.btnAddExpenseType_Click);
      // 
      // txtIncome
      // 
      this.txtIncome.Location = new System.Drawing.Point(105, 285);
      this.txtIncome.Name = "txtIncome";
      this.txtIncome.Size = new System.Drawing.Size(100, 20);
      this.txtIncome.TabIndex = 6;
      this.txtIncome.Text = "0.00";
      this.txtIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // dtEnding
      // 
      this.dtEnding.Location = new System.Drawing.Point(94, 181);
      this.dtEnding.MaxDate = new System.DateTime(2010, 12, 31, 0, 0, 0, 0);
      this.dtEnding.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
      this.dtEnding.Name = "dtEnding";
      this.dtEnding.Size = new System.Drawing.Size(200, 20);
      this.dtEnding.TabIndex = 7;
      // 
      // dtStarting
      // 
      this.dtStarting.Location = new System.Drawing.Point(94, 155);
      this.dtStarting.MaxDate = new System.DateTime(2010, 12, 31, 0, 0, 0, 0);
      this.dtStarting.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
      this.dtStarting.Name = "dtStarting";
      this.dtStarting.Size = new System.Drawing.Size(200, 20);
      this.dtStarting.TabIndex = 8;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 159);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 13);
      this.label1.TabIndex = 9;
      this.label1.Text = "Starting :";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 187);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(46, 13);
      this.label2.TabIndex = 10;
      this.label2.Text = "Ending :";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(15, 288);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(48, 13);
      this.label3.TabIndex = 11;
      this.label3.Text = "Income :";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(15, 314);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(54, 13);
      this.label4.TabIndex = 13;
      this.label4.Text = "Expense :";
      // 
      // txtExpense
      // 
      this.txtExpense.Location = new System.Drawing.Point(105, 311);
      this.txtExpense.Name = "txtExpense";
      this.txtExpense.Size = new System.Drawing.Size(100, 20);
      this.txtExpense.TabIndex = 12;
      this.txtExpense.Text = "0.00";
      this.txtExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(15, 340);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(51, 13);
      this.label5.TabIndex = 15;
      this.label5.Text = "Savings :";
      // 
      // txtSavings
      // 
      this.txtSavings.Location = new System.Drawing.Point(105, 337);
      this.txtSavings.Name = "txtSavings";
      this.txtSavings.Size = new System.Drawing.Size(100, 20);
      this.txtSavings.TabIndex = 14;
      this.txtSavings.Text = "0.00";
      this.txtSavings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // btnCalculate
      // 
      this.btnCalculate.Location = new System.Drawing.Point(166, 229);
      this.btnCalculate.Name = "btnCalculate";
      this.btnCalculate.Size = new System.Drawing.Size(75, 23);
      this.btnCalculate.TabIndex = 16;
      this.btnCalculate.Text = "Calculate";
      this.btnCalculate.UseVisualStyleBackColor = true;
      this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
      // 
      // FormTest
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(406, 496);
      this.Controls.Add(this.btnCalculate);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtSavings);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtExpense);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dtStarting);
      this.Controls.Add(this.dtEnding);
      this.Controls.Add(this.txtIncome);
      this.Controls.Add(this.btnAddExpense);
      this.Controls.Add(this.btnAddExpenseType);
      this.Controls.Add(this.btnAddBank);
      this.Controls.Add(this.btnAddIncome);
      this.Controls.Add(this.btnAddBankAccount);
      this.Controls.Add(this.btnAddIncomeType);
      this.Name = "FormTest";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnAddIncomeType;
    private System.Windows.Forms.Button btnAddBankAccount;
    private System.Windows.Forms.Button btnAddIncome;
    private System.Windows.Forms.Button btnAddBank;
    private System.Windows.Forms.Button btnAddExpense;
    private System.Windows.Forms.Button btnAddExpenseType;
    private System.Windows.Forms.TextBox txtIncome;
    private System.Windows.Forms.DateTimePicker dtEnding;
    private System.Windows.Forms.DateTimePicker dtStarting;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtExpense;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtSavings;
    private System.Windows.Forms.Button btnCalculate;
  }
}

