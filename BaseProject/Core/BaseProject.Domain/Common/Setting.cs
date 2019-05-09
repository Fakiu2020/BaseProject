using Whoever.Entities;

namespace BaseProject.Domain
{
    public partial class Setting : Entity
    {
        public decimal KioskLicensingFeePerMonth { get; set; }
        public decimal KioskLeasingFeePerMonth { get; set; }
        public decimal? AnnualMaintenanceFee { get; set; }
        public string AnnualMaintenanceFeeMessage { get; set; }
        public string SignupSubcriptionMessage { get; set; }
    }
}
