using Mumbi.Application.Parameters;

namespace Mumbi.Application.Dtos.Moms
{
    public class MomInfoRequest : RequestParameter
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}