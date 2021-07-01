using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class MomRepository : GenericRepository<MomInfo>, IMomRepository
    {
        private readonly DbSet<MomInfo> _mom;

        public MomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _mom = dbContext.Set<MomInfo>();
        }
    }
}
