using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;
using System.Threading.Tasks;

namespace Mumbi.Infrastucture.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly DbSet<Account> _account;

        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _account = dbContext.Set<Account>();
        }
    }
}
