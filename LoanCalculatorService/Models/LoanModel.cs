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

    public class LoanQuaterly : Loan
    {
        public LoanQuaterly(Decimal Interest) : base (Interest)
        {
        }

        //since we calculate interest rate quaterly, override default monthly calcuation
        public override List<Payment> CalculatePayments(Decimal TotalAmount, UInt16 NumberOfYears)
        {
            if (NumberOfYears * 4 > UInt16.MaxValue)
                throw new ArgumentOutOfRangeException("CapitalizationPeriods");

            var monthlyInterest = this.Interest / 4;
            var monthlyCapitalizationPeriods = (ushort)(NumberOfYears * 4);
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
