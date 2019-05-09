using AutoMapper;
using BaseProject.Application.Users.CreateUser;
using BaseProject.Domain;
using MediatR;
using Whoever.Common.Mapping;

namespace BaseProject.Application.Users.Administrators.Commands.CreateAdministrator
{
    public class CreateAdministratorCommand : CreateUserCommand, IRequest<int>, IHaveCustomMapping
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<CreateAdministratorCommand, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));
                //.ForMember(x => x.Administrator, opt => opt.MapFrom(x => new Administrator() {
                //    FirstName = x.FirstName,
                //    LastName = x.LastName
                //}));
        }
    }
}
