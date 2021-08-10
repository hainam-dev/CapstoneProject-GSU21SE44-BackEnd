using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class ChildInfoRepository : GenericRepository<ChildInfo>, IChildInfoRepository
    {
        private readonly DbSet<ChildInfo> _child;

        public ChildInfoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _child = dbContext.Set<ChildInfo>();
        }
    }
}