using Mumbi.Application.Dtos.Tokens;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface ITokenService
    {
        Task<Response<string>> DeleteToken(string userId, string fcmToken);
    }
}
