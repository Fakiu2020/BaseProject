
using System.Collections.Generic;
using Whoever.Entities;

namespace BaseProject.Domain
{

    public partial class State : Entity
    {
        public const int MichiganStateId = 29;

        public State()
        {
            Addresses = new HashSet<Address>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ABR { get; set; }
        public decimal KioskLeasingSalesTaxPercentage { get; set; }

        public virtual ICollection<Address> Addresses { get; private set; }
    }
}
