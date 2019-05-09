using BaseProject.Application.Infrastructure.Request.Commands.Update;
using BaseProject.Domain;
using MediatR;
using Whoever.Common.Mapping;

namespace BaseProject.Application.Users.Administrators.Commands.UpdateAdministrator
{
    public class UpdateAdministratorCommand : UpdateCommand, IRequest, IMapTo<Administrator>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
