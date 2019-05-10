using System.Collections.Generic;
using AutoMapper;
using BaseProject.Application.Roles;
using BaseProject.Domain;
using MediatR;
using Whoever.Common.Mapping;

namespace BaseProject.Application.Users.CreateUser
{
    public class CreateUserCommand: IRequest<int>, IHaveCustomMapping
    {
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<string> Roles { get; set; }


        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<CreateUserCommand, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.Roles, opt => opt.Ignore());
        }
    }
}
