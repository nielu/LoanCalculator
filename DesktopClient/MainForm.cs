using SharedModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopClient
{
    public partial class MainForm : Form, IVIew
    {
        private Presenter presenter;

        public List<LoanType> LoanTypeList
        {
            get => throw new NotImplementedException();
            set => populateLoanTypeComboBox(value);
        }

        public List<Payment> PaymentList
        {
            get => throw new NotImplementedException();
            set => populatePaymentLIstView(value);
        }

        public MainForm()
        {
            InitializeComponent();
            presenter = new Presenter("http://localhost:6356/", this);
        }

        private void populatePaymentLIstView(List<Payment> payments)
        {
            paymentsListView.Items.Clear();

            foreach (var p in payments)
                paymentsListView.Items.Add(generatePaymentRow(p));
        }

        private void populateLoanTypeComboBox(List<LoanType> loanTypes)
        {
            loanTypeComboBox.Items.Clear();

            loanTypeComboBox.Items.AddRange(loanTypes.ToArray());
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                await presenter.GetLoanTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occured during startup: {ex.ToString()}");
                Close();
            }
        }

        private async void executeButton_Click(object sender, EventArgs e)
        {
            UInt16 years;
            Decimal amount;
            var selectedLoan = loanTypeComboBox.SelectedItem as LoanType;
            
            if (!UInt16.TryParse(yearsTextBox.Text, out years))
            {
                MessageBox.Show("Invalid input: years");
                return;
            }

            if (!Decimal.TryParse(totalAmountTextBox.Text, out amount))
            {
                MessageBox.Show("Invalid input: Amount");
                return;
            }

            await presenter.GetPayments(amount, years, selectedLoan.LoanTypeID);
        }

        private async void loanTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = loanTypeComboBox.SelectedItem as LoanType;
            var interest = await presenter.GetInterest(selectedItem.LoanTypeID);
            interestTextBox.Text = interest.ToString("P");

            executeButton.Enabled = true;
        }

        private ListViewItem generatePaymentRow(Payment p)
        {
            var item = new ListViewItem((p.PaymentNo + 1).ToString());
            item.SubItems.Add(p.Capital.ToString("C2"));
            item.SubItems.Add(p.Interest.ToString("C2"));
            item.SubItems.Add(p.Total.ToString("C2"));
            return item;
        }
    }
}
