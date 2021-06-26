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

        public IChildrenRepository ChildrenRepository { get; set; }

        public IPregnancyInformationRepository PregnancyInformationRepository { get; set; }

        public IDadRepository DadRepository { get; set; }
        public IDiaryRepository DiaryRepository { get; set; }
        public INewsRepository NewsRepository { get; set; }
        public INewsTypeRepository NewsTypeRepository { get; set; }
        public INewsMomRepository NewsMomRepository { get; set; }
        public IGuidebookRepository GuidebookRepository { get; set; }
        public IGuidebookTypeRepository GuidebookTypeRepository { get; set; }
        public IGuidebookMomRepository GuidebookMomRepository { get; set; }
        public IStaffRepository StaffRepository { get; set; }
        public ITokenRepository TokenRepository { get; set; }

        private void InitRepository()
        {
            RoleRepository = new RoleRepository(_context);
            AccountRepository = new AccountRepository(_context);
            MomRepository = new MomRepository(_context);
            ChildrenRepository = new ChildrenRepository(_context);
            PregnancyInformationRepository = new PregnancyInformationRepository(_context);
            DadRepository = new DadRepository(_context);
            DiaryRepository = new DiaryRepository(_context);
            NewsRepository = new NewsRepository(_context);
            NewsTypeRepository = new NewsTypeRepository(_context);
            NewsMomRepository = new NewsMomRepository(_context);
            GuidebookRepository = new GuidebookRepository(_context);
            GuidebookTypeRepository = new GuidebookTypeRepository(_context);
            GuidebookMomRepository = new GuidebookMomRepository(_context);
            StaffRepository = new StaffRepository(_context);
            TokenRepository = new TokenRepository(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
