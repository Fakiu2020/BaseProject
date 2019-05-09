namespace BaseProject.Application.Auth.Commands.Login
{
    public class LoginModel 
    {
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }

        public LoginModel(AccessToken accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
