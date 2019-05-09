using Whoever.Entities;

namespace BaseProject.Domain
{

    public partial class Day : Entity
    {
        public string Name { get; set; }
        public int? Number { get; set; }
    }
}
