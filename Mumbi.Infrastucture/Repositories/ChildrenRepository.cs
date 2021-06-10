using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class ChildrenRepository : GenericRepository<Child>, IChildrenRepository
    {
        private readonly DbSet<Child> _child;

        public ChildrenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _child = dbContext.Set<Child>();
        }
    }
}
