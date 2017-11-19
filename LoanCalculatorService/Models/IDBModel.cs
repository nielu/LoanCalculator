using System.Collections.Generic;
using SharedModels;

namespace LoanCalculatorService.Models
{
    public interface IDBModel
    {
        Loan GetLoan(ushort LoanTypeID);
        List<LoanType> GetLoanTypes();
    }
}