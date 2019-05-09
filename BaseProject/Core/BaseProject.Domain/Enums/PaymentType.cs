using Whoever.Entities.Common;

namespace BaseProject.Domain.Enums
{
    public abstract class PaymentType : Enumeration
    {
        public static PaymentType CreditCard = new CreditCardType();
        public static PaymentType Cash = new CashType();
        public static PaymentType Check = new CheckType();
        public static PaymentType WriteOff = new WriteOffType();

        protected PaymentType(int id, string name)
            : base(id, name)
        {
        }

        private class CreditCardType : PaymentType
        {
            public CreditCardType() : base(1, "Credit Card")
            { }
        }

        private class CashType : PaymentType
        {
            public CashType() : base(2, "Cash")
            { }
        }

        private class CheckType : PaymentType
        {
            public CheckType() : base(3, "Check")
            { }
        }

        private class WriteOffType : PaymentType
        {
            public WriteOffType() : base(4, "Write-Off")
            { }
        }

        public bool NeedCheckNumber { get { return this == Check; } }
        public bool IsBraintree { get { return this == CreditCard; } }

    }
}
