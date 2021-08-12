using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class ToothRepository : GenericRepository<ToothChild>, IToothChildRepository
    {
        private readonly DbSet<ToothChild> _toothChild;

        public ToothRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _toothChild = dbContext.Set<ToothChild>();
        }
    }
}