

using GeoAPI.Geometries;
using System.Collections.Generic;
using Whoever.Entities;

namespace BaseProject.Domain
{

    public partial class Address : Entity
    {
        public Address()
        {
            Gyms = new HashSet<Gym>();
            GymMembers = new HashSet<GymMember>();
            CreditCards = new HashSet<CreditCard>();
        }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string Zip { get; set; }
        public IPoint Location { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Gym> Gyms { get; private set; }
        public virtual ICollection<GymMember> GymMembers { get; private set; }
        public virtual ICollection<CreditCard> CreditCards { get; private set; }
    }

    public class AddressComparer : IEqualityComparer<Address>
    {
        public bool Equals(Address x, Address y)
        {
            return x.Address1 == y.Address1 && x.City == y.City && x.StateId == y.StateId;
        }

        public int GetHashCode(Address obj)
        {
            return obj.GetHashCode();
        }
    }
}
