using Mumbi.Domain.Entities;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces.Repositories
{
    public interface ITokenRepository : IGenericRepository<Token>
    {
        bool IsUniqueFCMTOken(string fcmToken);
    }
}
