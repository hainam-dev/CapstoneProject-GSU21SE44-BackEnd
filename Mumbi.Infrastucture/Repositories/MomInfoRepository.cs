using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class MomInfoRepository : GenericRepository<MomInfo>, IMomInfoRepository
    {
        private readonly DbSet<MomInfo> _momInfo;

        public MomInfoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _momInfo = dbContext.Set<MomInfo>();
        }
    }
}