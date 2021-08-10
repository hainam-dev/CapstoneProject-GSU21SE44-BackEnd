using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class ChildHistoryRepository : GenericRepository<ChildHistory>, IChildHistoryRepository
    {
        private readonly DbSet<ChildHistory> _childHistory;

        public ChildHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _childHistory = dbContext.Set<ChildHistory>();
        }
    }
}