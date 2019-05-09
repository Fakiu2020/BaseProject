using Whoever.Entities;

namespace BaseProject.Domain
{
    public partial class KioskFingerPrint : Entity
    {
        public int KioskId { get; set; }
        public string FingerPrintXml { get; set; }

        public virtual Kiosk Kiosk { get; set; }
    }
}
