using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;
using System.Linq;

namespace Mumbi.Infrastucture.Repositories
{
    public class TokenRepository : GenericRepository<Token>, ITokenRepository
    {
        private readonly DbSet<Token> _token;

        public TokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _token = dbContext.Set<Token>();
        }

        public bool IsUniqueFCMTOken(string fcmToken)
        {
            return _token.All(x => x.FcmToken != fcmToken);
        }
    }
}