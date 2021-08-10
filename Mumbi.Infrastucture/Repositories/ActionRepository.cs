using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class ActionRepository : GenericRepository<Domain.Entities.Action>, IActionRepository
    {
        private readonly DbSet<Domain.Entities.Action> _action;

        public ActionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _action = dbContext.Set<Domain.Entities.Action>();
        }
    }
}