using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;


namespace Mumbi.Infrastucture.Repositories
{
    public class DadInfoRepository : GenericRepository<DadInfo>, IDadInfoRepository
    {
        private readonly DbSet<DadInfo> _dadInfo;

        public DadInfoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dadInfo = dbContext.Set<DadInfo>();
        }
    }
}
