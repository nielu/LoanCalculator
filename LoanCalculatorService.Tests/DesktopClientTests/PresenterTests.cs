using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesktopClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Mocks;

namespace DesktopClient.Tests
{
    [TestClass()]
    public class PresenterTests
    {
        string validURI = "http://localhost:6356/";

        [TestMethod()]
        public async Task GetPaymentsTest()
        {
            var view = MockRepository.GenerateMock<IVIew>();
            view.Stub(v => v.PaymentList).PropertyBehavior();

            var presenter = new Presenter(validURI, view);

            await presenter.GetPayments(1000M, 25, 0);

            Assert.IsTrue(view.PaymentList.Count > 0);
        }

        [TestMethod()]
        public async Task GetInterestTest()
        {
            var view = MockRepository.GenerateMock<IVIew>();
            var presenter = new Presenter(validURI, view);
            var interest = await presenter.GetInterest(0);

            Assert.AreEqual(interest, 0.0314M);
        }

        [TestMethod()]
        public async Task GetLoanTypesTest()
        {
            var view = MockRepository.GenerateMock<IVIew>();
            view.Stub(v => v.LoanTypeList).PropertyBehavior();

            var presenter = new Presenter(validURI, view);

            await presenter.GetLoanTypes();

            Assert.IsTrue(view.LoanTypeList.Count > 0);
        }
    }
}