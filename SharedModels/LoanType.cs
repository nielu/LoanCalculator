using System;

namespace SharedModels
{
    public class LoanType
    {
        public UInt16 LoanTypeID { get; set; }
        public String LoanText { get; set; }

        public override string ToString()
        {
            return LoanText;
        }
    }
}
