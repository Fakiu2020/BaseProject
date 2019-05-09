using AutoMapper;
using BaseProject.Application.Users.Common;
using BaseProject.Domain;
using MediatR;
using Whoever.Common.Mapping;

namespace BaseProject.Application.Auth.Commands.Login
{

    public class RegisterCommand : CreateUserCommand,IRequest<int>, IHaveCustomMapping
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<RegisterCommand, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
