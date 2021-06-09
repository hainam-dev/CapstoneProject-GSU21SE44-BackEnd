using Mumbi.Application.Dtos;
using Mumbi.Application.Dtos.Accounts;
using Mumbi.Application.Wrappers;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> Authenticate(AuthenticationRequest request);
    }
}
