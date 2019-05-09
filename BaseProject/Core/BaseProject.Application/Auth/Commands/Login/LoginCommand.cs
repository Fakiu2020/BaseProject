using AutoMapper;
using BaseProject.Domain;
using MediatR;
using Whoever.Common.Mapping;

namespace BaseProject.Application.Auth.Commands.Login
{

    public class LoginCommand : IRequest<LoginModel>
    {
        
        public string Email{ get; set; }
        public string Password { get; set; }

    }
}
