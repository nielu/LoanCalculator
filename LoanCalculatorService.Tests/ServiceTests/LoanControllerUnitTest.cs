using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoanCalculatorService.Controllers;

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

            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => controller.GetInterest(ushort.MaxValue));
        }


    }
}
