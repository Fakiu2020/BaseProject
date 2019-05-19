using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BaseProject.Application.Interfaces;
using BaseProject.Application.Managers;
using BaseProject.Domain;
using BaseProject.Persistence;
using FluentValidation.Results;
using MediatR;
using Whoever.Common.Exceptions;

namespace BaseProject.Application.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginModel>
    {
        private readonly BaseProjectDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager _userManager;
        private readonly ITokenFactory _tokenFactory;
        private readonly IJwtFactory _jwtFactory;

        public LoginCommandHandler(BaseProjectDbContext context, IMapper mapper, UserManager userManager, ITokenFactory tokenFactory, IJwtFactory jwtFactory)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _tokenFactory = tokenFactory;
            _jwtFactory = jwtFactory;
        }

        public async Task<LoginModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // ensure we have a user with the given user name
                var user = await _userManager.FindByNameAsync(request.Email);
                if (user == null)
                {
                    ValidationFailure[] errors = new ValidationFailure[] { new ValidationFailure("Email", "Invalid Email") };
                    throw new ValidationException(errors); //nameof(LoginCommand.Password), "Invalid UserName or Password");
                }

                var validPassword = await _userManager.CheckPasswordAsync(user, request.Password);
                if (!validPassword)
                {
                    ValidationFailure[] errors = new ValidationFailure[] { new ValidationFailure("Password", "Invalid Password") };
                    throw new ValidationException(errors); //nameof(LoginCommand.Password), "Invalid UserName or Password");
                }


                // generate refresh token
                var token = _tokenFactory.GenerateToken();
                //var refreshToken = new RefreshToken(token, DateTime.UtcNow.AddDays(5), user.Id, request.RemoteIpAddress);
                //_context.RefreshTokens.Add(refreshToken);
                //await _context.SaveChangesAsync();

                var accessToken = await _jwtFactory.GenerateEncodedToken(user.Id.ToString(), user.UserName);
                return new LoginModel(accessToken, token);
            }
            catch (System.Exception ex)
            {

                throw new ValidationException();
            }
           
        }
    }
}
