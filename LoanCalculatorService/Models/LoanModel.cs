using System;
using System.Collections.Generic;

namespace SharedModels
{
    public class Loan
    {
        public Loan(Decimal interest)
        {
            Interest = interest;
        }

        public Decimal Interest;

        public virtual List<Payment> CalculatePayments(Decimal TotalAmount, UInt16 NumberOfYears)
        {
            var paymentList = new List<Payment>();
            var periodCapital = TotalAmount / NumberOfYears;

            for (UInt16 i = 0; i < NumberOfYears; ++i)
            {
                var currentPayment = new Payment
                {
                    PaymentNo = i,
                    Capital = periodCapital,
                    Interest = TotalAmount * this.Interest
                };
                paymentList.Add(currentPayment);

                TotalAmount -= periodCapital;
            }

            return paymentList;
        }
    }

    public class CarLoanMonthly : Loan
    {
        public CarLoanMonthly(Decimal Interest) : base (Interest)
        {
        }

        //since we calculate interest rate monthly,
        public override List<Payment> CalculatePayments(Decimal TotalAmount, UInt16 NumberOfYears)
        {
            if (NumberOfYears * 12 > UInt16.MaxValue)
                throw new ArgumentOutOfRangeException("CapitalizationPeriods");

            var monthlyInterest = this.Interest / 12;
            var monthlyCapitalizationPeriods = (ushort)(NumberOfYears * 12);
            var monthlyCapital = TotalAmount / monthlyCapitalizationPeriods;
            var paymentList = new List<Payment>();

            for (ushort i = 0; i < monthlyCapitalizationPeriods; ++i)
            {
                var currentPayment = new Payment
                {
                    PaymentNo = i,
                    Capital = monthlyCapital,
                    Interest = TotalAmount * monthlyInterest
                };
                paymentList.Add(currentPayment);

                TotalAmount -= monthlyCapital;
            }

            return paymentList;
        }
    }
}
