using SharedModels;
using System.Collections.Generic;

namespace DesktopClient
{
    public interface IVIew
    {
        List<LoanType> LoanTypeList { get; set; }
        List<Payment> PaymentList { get; set; }
    }
}
