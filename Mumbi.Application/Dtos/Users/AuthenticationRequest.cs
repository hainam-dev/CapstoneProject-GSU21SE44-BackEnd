namespace Mumbi.Application.Dtos.Accounts
{
    public class AuthenticationRequest
    {
        public string IdToken { get; set; }
        public string FCMToken { get; set; }
    }
}