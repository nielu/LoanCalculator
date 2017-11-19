using System;

namespace SharedModels
{
    public class Payment
    {
        public UInt16 PaymentNo { get; set; }
        public Decimal Capital { get; set; }
        public Decimal Interest { get; set; }
        public Decimal Total { get { return Capital + Interest; } }
    }
}
