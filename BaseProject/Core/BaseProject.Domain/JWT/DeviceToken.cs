using Whoever.Entities;

namespace BaseProject.Domain
{
    public class DeviceToken : Entity
    {
        public string DeviceId { get; set; }
        public string Token { get; set; }
        public string Version { get; set; }
        public byte? Platform { get; set; }

        public virtual User User { get; set; }
    }
}
