using LoanCalculatorService.Models;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LoanCalculatorService.Controllers
{
    public class LoanController : ApiController
    {
        private IDBModel _db = new DBMockModel();
        
        [HttpGet]
        public List<Payment> ReturnPayments(Decimal TotalAmount, UInt16 NumberOfYears, UInt16 LoanTypeID)
        {
            var loan = _db.GetLoan(LoanTypeID);

            return loan.CalculatePayments(TotalAmount, NumberOfYears);
        }

        [HttpGet]
        public Decimal GetInterest(UInt16 LoanTypeID)
        {
            return _db.GetLoan(LoanTypeID).Interest;
        }

        [HttpGet]
        public List<LoanType> GetLoanTypes()
        {
            return _db.GetLoanTypes();
        }
    }
}
