using System.Threading;
using System.Threading.Tasks;
using BaseProject.Application.Infrastructure.Request.Commands.Delete;
using BaseProject.Domain;
using BaseProject.Persistence;
using MediatR;

namespace BaseProject.Application.Common.CreditCards.Commands.DeleteCreditCard
{
    public class DeleteCreditCardCommandHandler : DeleteCommandHandler<CreditCard>, IRequestHandler<DeleteCreditCardCommand>
    {
        public DeleteCreditCardCommandHandler(BaseProjectDbContext db) : base(db)
        {
        }

        public Task<Unit> Handle(DeleteCreditCardCommand request, CancellationToken cancellationToken)
        {
            return base.Handle(request, cancellationToken);
        }
    }
}
