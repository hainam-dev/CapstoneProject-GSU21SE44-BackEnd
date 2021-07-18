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

        public IUserRepository UserRepository { get; set; }

        public IRoleRepository RoleRepository { get; set; }

        public IMomInfoRepository MomInfoRepository { get; set; }

        public IChildInfoRepository ChildInfoRepository { get; set; }
        public IChildHistoryRepository ChildHistoryRepository { get; set; }
        public IPregnancyHistoryRepository PregnancyHistoryRepository { get; set; }
        public IDadInfoRepository DadInfoRepository { get; set; }
        public IDiaryRepository DiaryRepository { get; set; }
        public INewsRepository NewsRepository { get; set; }
        public INewsTypeRepository NewsTypeRepository { get; set; }
        public INewsMomRepository NewsMomRepository { get; set; }
        public IGuidebookRepository GuidebookRepository { get; set; }
        public IGuidebookTypeRepository GuidebookTypeRepository { get; set; }
        public IGuidebookMomRepository GuidebookMomRepository { get; set; }
        public ITokenRepository TokenRepository { get; set; }
        public IUserInfoRepository UserInfoRepository { get; set; }
        public IToothRepository ToothRepository { get; set; }
        public IToothInfoRepository ToothInfoRepository { get; set; }
        public IInjectionScheduleRepository InjectionScheduleRepository { get; set; }
        public IInjectedPersonRepository InjectedPersonRepository { get; set; }


        private void InitRepository()
        {
            RoleRepository = new RoleRepository(_context);
            UserRepository = new UserRepository(_context);
            UserInfoRepository = new UserInfoRepository(_context);
            MomInfoRepository = new MomInfoRepository(_context);
            ChildInfoRepository = new ChildInfoRepository(_context);
            ChildHistoryRepository = new ChildHistoryRepository(_context);
            PregnancyHistoryRepository = new PregnancyHistoryRepository(_context);
            DadInfoRepository = new DadInfoRepository(_context);
            DiaryRepository = new DiaryRepository(_context);
            NewsRepository = new NewsRepository(_context);
            NewsTypeRepository = new NewsTypeRepository(_context);
            NewsMomRepository = new NewsMomRepository(_context);
            GuidebookRepository = new GuidebookRepository(_context);
            GuidebookTypeRepository = new GuidebookTypeRepository(_context);
            GuidebookMomRepository = new GuidebookMomRepository(_context);
            TokenRepository = new TokenRepository(_context);
            ToothRepository = new ToothRepository(_context);
            ToothInfoRepository = new ToothInfoRepository(_context);
            InjectionScheduleRepository = new InjectionScheduleRepository(_context);
            InjectedPersonRepository = new InjectedPersonRepository(_context);

        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
