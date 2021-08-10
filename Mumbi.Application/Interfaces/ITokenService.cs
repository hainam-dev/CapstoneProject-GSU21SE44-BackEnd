using Mumbi.Application.Wrappers;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface ITokenService
    {
        Task<Response<string>> DeleteToken(string userId, string fcmToken);
    }
}