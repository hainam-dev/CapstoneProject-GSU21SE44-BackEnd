namespace Mumbi.Application.Dtos
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Role { get; set; }
        public string Photo { get; set; }
        public string JWToken { get; set; }
    }
}
