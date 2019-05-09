namespace BaseProject.Application.Users.Common
{
    public class CreateUserCommand
    {
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
