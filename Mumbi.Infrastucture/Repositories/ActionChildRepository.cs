using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class ActionChildRepository : GenericRepository<ActionChild>, IActionChildRepository
    {
        private readonly DbSet<ActionChild> _actionChild;

        public ActionChildRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _actionChild = dbContext.Set<ActionChild>();
        }
    }
}