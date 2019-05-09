using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BaseProject.Application.Managers;
using BaseProject.Domain;
using BaseProject.Domain.Constants;
using BaseProject.Persistence;
using MediatR;
using Whoever.Common.Exceptions;
using Whoever.Common.Extensions;

namespace BaseProject.Application.Users.Administrators.Commands.CreateAdministrator
{
    public class CreateAdministratorCommandHandler : IRequestHandler<CreateAdministratorCommand, int>
    {
        private readonly BaseProjectDbContext _db;
        private readonly UserManager _userManager;
        private readonly IMapper _mapper;

        public CreateAdministratorCommandHandler(BaseProjectDbContext db, UserManager userManager, IMapper mapper)
        {
            _db = db;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAdministratorCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            using (var ts = _db.BeginTransaction())
            {
                try
                {
                    var result = await _userManager.CreateAsync(user, request.Password);

                    if (!result.Succeeded)
                    {
                        throw new ValidationException(result.ToValidationFailureList());
                    }

                    result = await _userManager.AddToRoleAsync(user, RolesNames.Admin.Name);
                    if (!result.Succeeded)
                    {
                        throw new ValidationException(result.ToValidationFailureList());
                    }

                    ts.Complete();
                    return user.Id;
                }
                catch (Exception ex)
                {
                    ex.ReThrow();
                    return 0;
                }
            }
                

        }
    }
}
