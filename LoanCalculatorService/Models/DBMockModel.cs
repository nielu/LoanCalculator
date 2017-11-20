using SharedModels;
using System;
using System.Collections.Generic;

namespace LoanCalculatorService.Models
{
    public class DBMockModel : IDBModel
    {
        private LoanType[] LoanTypeTable =
        {
            new LoanType {LoanTypeID = 0, LoanText = "House" },
            new LoanType {LoanTypeID = 1, LoanText = "Car" },
            new LoanType {LoanTypeID = 2, LoanText = "Car monthly interest"}
        };

        private Loan[] LoanTable =
        {
            new Loan(0.0314M),  //Interest as per example 3.14%
            new Loan(0.0429M),  //Interest based from bankrate.com for a new car on sept. 2017
            new CarLoanMonthly(0.0429M)
        };

        public Loan GetLoan(UInt16 LoanTypeID)
        {
            if (LoanTypeID >= LoanTable.Length)
                throw new ArgumentOutOfRangeException("LoanTypeID");

            return LoanTable[LoanTypeID];
        }

        public List<LoanType> GetLoanTypes()
        {
            return new List<LoanType>(LoanTypeTable);
        }

    }
}