using Whoever.Entities;

namespace BaseProject.Domain
{

    public partial class FingerPrint : Entity
    {
        public string FingerPrintXml { get; set; }

        public virtual User User { get; set; }
    }
}
