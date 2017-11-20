using SharedModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebServiceTestApp
{
    public class WebServiceApi
    {
        private HttpClient client = new HttpClient();
        private string getLoanTypesUrl = "api/Loan/GetLoanTypes";
        private string getInterestUrl = "api/Loan/GetInterest";
        private string returnPaymentsUrl = "api/Loan/ReturnPayments";

        public void Init(string serverUrl)
        {
            client.BaseAddress = new Uri(serverUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Payment>> GetPayments(Decimal TotalAmount, UInt16 NumberOfYears, UInt16 LoanTypeID)
        {
            var response = await client.GetAsync($"{returnPaymentsUrl}?TotalAmount={TotalAmount}&NumberOfYears={NumberOfYears}&LoanTypeID={LoanTypeID}");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<List<Payment>>();
            else
                throw new Exception();
        }

        public async Task<decimal> GetInterest(UInt16 LoanTypeID)
        {
            var response = await client.GetAsync($"{getInterestUrl}?LoanTypeID={LoanTypeID}");
            var interest = 0M;
            if (response.IsSuccessStatusCode)
                interest = await response.Content.ReadAsAsync<Decimal>();
            else
                throw new Exception();

            return interest;
        }

        public async Task<List<LoanType>> GetLoanTypes()
        {
            var response = await client.GetAsync(getLoanTypesUrl);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<List<LoanType>>();
            else
                throw new Exception("Could not connect to server!");

        }
    }
}
