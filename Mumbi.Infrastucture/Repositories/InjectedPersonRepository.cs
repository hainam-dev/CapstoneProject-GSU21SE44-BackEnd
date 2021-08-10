using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class InjectedPersonRepository : GenericRepository<InjectedPerson>, IInjectedPersonRepository
    {
        private readonly DbSet<InjectedPerson> _child;

        public InjectedPersonRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _child = dbContext.Set<InjectedPerson>();
        }
    }
}