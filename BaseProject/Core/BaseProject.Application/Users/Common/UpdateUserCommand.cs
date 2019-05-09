using BaseProject.Application.Infrastructure.Request.Commands.Update;

namespace BaseProject.Application.Users.Common
{
    public class UpdateUserCommand : UpdateCommand
    {
        public string Email { get; set; }
    }
}
