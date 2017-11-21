using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace SharedModels.Tests
{
    [TestClass()]
    public class LoanTests
    {
        [TestMethod()]
        public void CalculatePaymentsTest()
        {
            var loan = new Loan(0.0314M);
            UInt16 years = 10;
            var totalAmount = 10000M;

            var payments = loan.CalculatePayments(totalAmount, years);
            var totalCost = payments.Sum(p => p.Total);

            //compound interest equation
            var correctCost = seriesLoanTotalCost(years, 12, totalAmount, loan.Interest);
            
            Assert.AreEqual(Decimal.Round(totalCost, 3), Decimal.Round(correctCost, 3));

        }

        [TestMethod()]
        public void CalculateQuaterlyPaymentTest()
        {
            var loan = new LoanQuaterly(0.0314M);
            UInt16 years = 10;
            var totalAmount = 10000M;

            var payments = loan.CalculatePayments(totalAmount, years);
            var totalCost = payments.Sum(p => p.Total);
            
            var correctCost = seriesLoanTotalCost(years, 4, totalAmount, loan.Interest);

            Assert.AreEqual(Decimal.Round(totalCost, 3), Decimal.Round(correctCost, 3));
        }

        [TestMethod()]
        public void CalculatePaymentDivideZeroTest()
        {
            var loan = new Loan(0.01M);

            Assert.ThrowsException<ArgumentException>(
                () => loan.CalculatePayments(2000M, 0)); //will fail
        }

        private Decimal seriesLoanTotalCost(UInt16 NumberOfYears, UInt16 CapitalizationsPerYear, Decimal TotalAmount, Decimal Interest)
        {
            var sum = 0M;
            var payment = TotalAmount / (NumberOfYears * CapitalizationsPerYear);

            for (UInt16 i = 0; i < CapitalizationsPerYear * NumberOfYears; ++i)
            {
                var currentInterest = TotalAmount * Interest / CapitalizationsPerYear;
                sum += payment + currentInterest;
                TotalAmount -= payment;
            }

            return sum;
        }
    }
        
}