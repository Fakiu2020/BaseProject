using Whoever.Entities.Common;

namespace BaseProject.Domain.Enums
{
    public abstract class SubMerchantAccountStatus : Enumeration
    {
        public static SubMerchantAccountStatus Approved = new ApprovedType();
        public static SubMerchantAccountStatus Declined = new DeclinedType();

        protected SubMerchantAccountStatus(int id, string name)
            : base(id, name)
        {
        }

        private class ApprovedType : SubMerchantAccountStatus
        {
            public ApprovedType() : base(0, "Approved")
            { }
        }

        private class DeclinedType : SubMerchantAccountStatus
        {
            public DeclinedType() : base(1, "Declined")
            { }
        }
    }
}
