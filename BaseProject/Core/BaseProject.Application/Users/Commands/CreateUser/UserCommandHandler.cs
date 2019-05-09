using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BaseProject.Application.Interfaces;
using BaseProject.Application.Managers;
using BaseProject.Application.Users.CreateUser;
using BaseProject.Domain;
using BaseProject.Persistence;
using MediatR;
using Whoever.Common.Exceptions;
using Whoever.Common.Extensions;

namespace BaseProject.Application.Auth.Commands.Login
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly BaseProjectDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager _userManager;
        private readonly ITokenFactory _tokenFactory;
        private readonly IJwtFactory _jwtFactory;

        public UserCommandHandler(BaseProjectDbContext context, IMapper mapper, UserManager userManager, ITokenFactory tokenFactory, IJwtFactory jwtFactory)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _tokenFactory = tokenFactory;
            _jwtFactory = jwtFactory;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            using (var ts = _context.BeginTransaction())
            {
                try
                {
                    var result = await _userManager.CreateAsync(user, request.Password);

                    if (!result.Succeeded)
                    {
                        throw new ValidationException(result.ToValidationFailureList());
                    }

                    //result = await _userManager.AddToRoleAsync(user, RolesNames.Admin.Name);
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
