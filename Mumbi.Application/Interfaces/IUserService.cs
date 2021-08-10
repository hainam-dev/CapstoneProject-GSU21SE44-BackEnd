using Mumbi.Application.Dtos;
using Mumbi.Application.Dtos.Accounts;
using Mumbi.Application.Wrappers;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IUserService
    {
        Task<Response<AuthenticationResponse>> Authenticate(AuthenticationRequest request);
    }
}