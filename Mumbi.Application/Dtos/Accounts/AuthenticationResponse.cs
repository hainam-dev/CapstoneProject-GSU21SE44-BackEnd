namespace Mumbi.Application.Dtos
{
    public class AuthenticationResponse
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string Photo { get; set; }
        public string JWToken { get; set; }
    }
}
