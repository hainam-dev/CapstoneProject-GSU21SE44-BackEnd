using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class MomRepository : GenericRepository<Mom>, IMomRepository
    {
        private readonly DbSet<Mom> _mom;

        public MomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _mom = dbContext.Set<Mom>();
        }
    }
}
