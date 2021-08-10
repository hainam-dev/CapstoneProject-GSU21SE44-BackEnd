namespace Mumbi.Application.Dtos.Tokens
{
    public class FcmTokenResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FcmToken { get; set; }
    }
}