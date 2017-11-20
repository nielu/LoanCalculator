using System;
using System.Net;
using SharedModels;
using static WebServiceTestApp.Helpers;
namespace WebServiceTestApp
{
    public class VerifyEndpoint_01 : ITestCase
    {
        public void Cleanup()
        {
            //stop webservice
            return;
        }

        public void Execute()
        {
            var urlToTest = "http://localhost:6356/api/Loan/InvalidRequest";
            LogMessage($"Trying to open {urlToTest}");

            var request = WebRequest.Create(urlToTest);

            try
            {
                var response = request.GetResponse();
                LogMessage("GetResponse did not throw an exception, presumably valid request!", LogLevel.FAIL);
                LogMessage($"Response contents: {request.ToString()}");
            }
            catch (Exception e)
            {
                if (e.Message.Contains("404"))
                {
                    LogMessage("Request returned 404, as expected", LogLevel.PASS);
                }
                else
                {
                    LogMessage($"Unrecognized exception was returned. {e.ToString()}", LogLevel.FAIL);
                }
            }
            
        }

        public void Prepare()
        {
            //Startup web service? 
            return;
        }
    }

    public class ReturnPayments_01 : WebServiceApi, ITestCase
    {
        public void Cleanup()
        {
            return;
        }

        public void Execute()
        {
            UInt16 years = 5;
            Decimal amount = 15000M;
            var everythingOK = true;

            LogMessage("Getting loans from server");
            var loans = GetLoanTypes().Result;
            LogMessage($"Selecting first available loan {loans[0]}");

            LogMessage($"Reading list of payments for {years} years and {amount}$");
            var payments = GetPayments(amount, years, loans[0].LoanTypeID).Result;
            LogMessage($"Got {payments.Count} payments, checking");

            foreach (var p in payments)
            {
                if (!isPaymentCorrect(p))
                {
                    LogMessage($"Invalid payment! {p}", LogLevel.FAIL);
                    everythingOK = false;
                }
            }

            if (everythingOK)
                LogMessage("Payments are correct", LogLevel.PASS);

        }

        private bool isPaymentCorrect(Payment p)
        {
            return true;
        }

        public void Prepare()
        {
            //Startup web service?
            Init("http://localhost:6356");
            return;
        }
    }
}
