using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class ChildrenRepository : GenericRepository<ChildInfo>, IChildrenRepository
    {
        private readonly DbSet<ChildInfo> _child;

        public ChildrenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _child = dbContext.Set<ChildInfo>();
        }
    }
}
