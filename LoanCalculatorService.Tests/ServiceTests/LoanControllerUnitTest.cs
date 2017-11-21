using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoanCalculatorService.Controllers;
using System.Web.Http;

namespace LoanCalculatorService.Tests
{
    [TestClass]
    public class LoanControllerUnitTest
    {
        [TestMethod]
        public void GetLoanTypesTest()
        {
            var controller = new LoanController();

            var availableLoans = controller.GetLoanTypes();

            Assert.IsTrue(availableLoans.Count > 0);
        }

        [TestMethod]
        public void GetInterestValidTest()
        {
            var controller = new LoanController();

            var interest = controller.GetInterest(0);

            Assert.IsTrue(interest == 0.0314M);
        }

        [TestMethod]
        public void GetInterestExceptionTest()
        {
            var controller = new LoanController();

            Assert.ThrowsException<HttpResponseException>
                (() => controller.GetInterest(ushort.MaxValue));
        }


        [TestMethod]
        public void GetPaymentsTest()
        {
            var controller = new LoanController();
            var availableLoans = controller.GetLoanTypes();

            var payments = controller.ReturnPayments(1000M, 5, availableLoans[0].LoanTypeID);

            Assert.IsTrue(payments.Count > 0);
        }

        [TestMethod]
        public void GetPaymentExceptionTest()
        {
            var controller = new LoanController();
            var loanID = controller.GetLoanTypes()[0].LoanTypeID;

            Assert.ThrowsException<HttpResponseException>(
                () => controller.ReturnPayments(1000, UInt16.MaxValue, loanID));
        }

    }
}
