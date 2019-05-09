using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseProject.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BaseProject.Application.Common.CreditCards.Queries.GetCreditCardsList
{
    public class GetCreditCardsListQueryHandler : IRequestHandler<GetCreditCardListQuery, List<CreditCardLookupModel>>
    {
        private readonly BaseProjectDbContext _context;
        private readonly IMapper _mapper;

        public GetCreditCardsListQueryHandler(BaseProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<CreditCardLookupModel>> Handle(GetCreditCardListQuery request, CancellationToken cancellationToken)
        {
            var query = _context.CreditCards.AsQueryable();
            var ccs = from cc in query
                      where cc.UserId == request.UserId
                      select cc;

            return ccs.ProjectTo<CreditCardLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}
