using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class InjectionScheduleRepository : GenericRepository<InjectionSchedule>, IInjectionScheduleRepository
    {
        private readonly DbSet<InjectionSchedule> _child;

        public InjectionScheduleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _child = dbContext.Set<InjectionSchedule>();
        }
    }
}