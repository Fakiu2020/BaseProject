using MediatR;
using System.Collections.Generic;

namespace BaseProject.Application.Common.CreditCards.Queries.GetCreditCardsList
{
    public class GetCreditCardListQuery : IRequest<List<CreditCardLookupModel>>
    {
        public int UserId { get; set; }
    }
}
