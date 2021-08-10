using Mumbi.Domain.Entities;

namespace Mumbi.Application.Interfaces.Repositories
{
    public interface ITokenRepository : IGenericRepository<Token>
    {
        bool IsUniqueFCMTOken(string fcmToken);
    }
}