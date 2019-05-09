using BaseProject.Domain;
using Whoever.Common.Mapping;

namespace BaseProject.Application.Common.CreditCards.Queries.GetCreditCardsList
{
    public class CreditCardLookupModel : IMapFrom<CreditCard>
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string CardType { get; set; }
        public string LastFourNumbers { get; set; }
        public bool IsDefault { get; set; }
    }
}
