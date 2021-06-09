using Mumbi.Application.Interfaces;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Infrastucture.Context;
using Mumbi.Infrastucture.Repositories;
using System.Threading.Tasks;

namespace Mumbi.Infrastucture.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            InitRepository();
        }

        public IAccountRepository AccountRepository { get; set; }

        public IRoleRepository RoleRepository { get; set; }

        public IMomRepository MomRepository { get; set; }

        private void InitRepository()
        {
            RoleRepository = new RoleRepository(_context);
            AccountRepository = new AccountRepository(_context);
            MomRepository = new MomRepository(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
