using LoanCalculatorService.Models;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace LoanCalculatorService.Controllers
{
    public class LoanController : ApiController
    {
        private IDBModel _db = new DBMockModel();
        
        [HttpGet]
        public List<Payment> ReturnPayments(Decimal TotalAmount, UInt16 NumberOfYears, UInt16 LoanTypeID)
        {
            Loan l;
            try
            {
                l = _db.GetLoan(LoanTypeID);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            try
            {
                return l.CalculatePayments(TotalAmount, NumberOfYears);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public Decimal GetInterest(UInt16 LoanTypeID)
        {
            try
            {
                return _db.GetLoan(LoanTypeID).Interest;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        public List<LoanType> GetLoanTypes()
        {
            return _db.GetLoanTypes();
        }
    }
}
