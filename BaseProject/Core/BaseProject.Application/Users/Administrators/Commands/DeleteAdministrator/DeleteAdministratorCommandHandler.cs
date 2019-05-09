using System;
using System.Threading;
using System.Threading.Tasks;
using BaseProject.Application.Infrastructure.Request.Commands.Delete;
using BaseProject.Application.Managers;
using BaseProject.Domain;
using BaseProject.Persistence;
using MediatR;
using Whoever.Common.Exceptions;
using Whoever.Common.Extensions;

namespace BaseProject.Application.Common.Administrators.Commands.DeleteAdministrator
{
    public class DeleteAdministratorCommandHandler : DeleteCommandHandler<Administrator>, IRequestHandler<DeleteAdministratorCommand>
    {
        private readonly UserManager _userManager;

        public DeleteAdministratorCommandHandler(BaseProjectDbContext db, UserManager userManager) : base(db)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(DeleteAdministratorCommand request, CancellationToken cancellationToken)
        {
            using(var ts = await Db.Database.BeginTransactionAsync())
            {
                try
                {
                    await base.Handle(request, cancellationToken);

                    var user = await _userManager.FindByIdAsync(request.Id.ToString());
                    var result = await _userManager.DeleteAsync(user);
                    if (!result.Succeeded)
                    {
                        throw new ValidationException(result.ToValidationFailureList());
                    }
                    ts.Commit();
                    return Unit.Value;
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                    ex.ReThrow();
                    return Unit.Value;
                }

            }
        }
    }
}
