using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BaseProject.Application.Infrastructure.Request.Commands.Update;
using BaseProject.Application.Managers;
using BaseProject.Domain;
using BaseProject.Persistence;
using MediatR;
using Whoever.Common.Exceptions;
using Whoever.Common.Extensions;

namespace BaseProject.Application.Users.Administrators.Commands.UpdateAdministrator
{
    public class UpdateAdministratorCommandHandler : UpdateCommandHandler<Administrator>, IRequestHandler<UpdateAdministratorCommand>
    {
        private readonly UserManager _userManager;

        public UpdateAdministratorCommandHandler(UserManager userManager, BaseProjectDbContext db, IMapper mapper)
            : base(db, mapper)
        {
            _userManager = userManager;
        }

        public Task<Unit> Handle(UpdateAdministratorCommand request, CancellationToken cancellationToken)
        {
            return base.Handle(request, cancellationToken);
        }

        protected override void UpdateValues(Administrator newValues, Administrator original)
        {
            original.FirstName = newValues.FirstName;
            original.LastName = newValues.LastName;
        }
    }
}
