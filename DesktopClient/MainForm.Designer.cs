namespace DesktopClient
{
    partial class MainForm
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
            this.executeButton = new System.Windows.Forms.Button();
            this.loanTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.interestTextBox = new System.Windows.Forms.TextBox();
            this.yearsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.paymentsListView = new System.Windows.Forms.ListView();
            this.PaymentID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Capital = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Interest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.totalAmountTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // executeButton
            // 
            this.executeButton.Enabled = false;
            this.executeButton.Location = new System.Drawing.Point(221, 32);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(121, 23);
            this.executeButton.TabIndex = 0;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // loanTypeComboBox
            // 
            this.loanTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loanTypeComboBox.FormattingEnabled = true;
            this.loanTypeComboBox.Location = new System.Drawing.Point(75, 6);
            this.loanTypeComboBox.Name = "loanTypeComboBox";
            this.loanTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.loanTypeComboBox.TabIndex = 1;
            this.loanTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.loanTypeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loan type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Interest";
            // 
            // interestTextBox
            // 
            this.interestTextBox.Enabled = false;
            this.interestTextBox.Location = new System.Drawing.Point(266, 7);
            this.interestTextBox.Name = "interestTextBox";
            this.interestTextBox.Size = new System.Drawing.Size(76, 20);
            this.interestTextBox.TabIndex = 4;
            // 
            // yearsTextBox
            // 
            this.yearsTextBox.Location = new System.Drawing.Point(441, 6);
            this.yearsTextBox.Name = "yearsTextBox";
            this.yearsTextBox.Size = new System.Drawing.Size(69, 20);
            this.yearsTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Years";
            // 
            // paymentsListView
            // 
            this.paymentsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PaymentID,
            this.Capital,
            this.Interest,
            this.Total});
            this.paymentsListView.Location = new System.Drawing.Point(12, 61);
            this.paymentsListView.Name = "paymentsListView";
            this.paymentsListView.Size = new System.Drawing.Size(498, 354);
            this.paymentsListView.TabIndex = 7;
            this.paymentsListView.UseCompatibleStateImageBehavior = false;
            this.paymentsListView.View = System.Windows.Forms.View.Details;
            // 
            // PaymentID
            // 
            this.PaymentID.Text = "PaymentID";
            this.PaymentID.Width = 97;
            // 
            // Capital
            // 
            this.Capital.Text = "Capital";
            this.Capital.Width = 131;
            // 
            // Interest
            // 
            this.Interest.Text = "Interest";
            this.Interest.Width = 139;
            // 
            // Total
            // 
            this.Total.Text = "Total";
            this.Total.Width = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Amount:";
            // 
            // totalAmountTextBox
            // 
            this.totalAmountTextBox.Location = new System.Drawing.Point(75, 34);
            this.totalAmountTextBox.Name = "totalAmountTextBox";
            this.totalAmountTextBox.Size = new System.Drawing.Size(121, 20);
            this.totalAmountTextBox.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 427);
            this.Controls.Add(this.totalAmountTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.paymentsListView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yearsTextBox);
            this.Controls.Add(this.interestTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loanTypeComboBox);
            this.Controls.Add(this.executeButton);
            this.Name = "MainForm";
            this.Text = "Loan Calculator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.ComboBox loanTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox interestTextBox;
        private System.Windows.Forms.TextBox yearsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView paymentsListView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox totalAmountTextBox;
        private System.Windows.Forms.ColumnHeader PaymentID;
        private System.Windows.Forms.ColumnHeader Capital;
        private System.Windows.Forms.ColumnHeader Interest;
        private System.Windows.Forms.ColumnHeader Total;
    }
}

