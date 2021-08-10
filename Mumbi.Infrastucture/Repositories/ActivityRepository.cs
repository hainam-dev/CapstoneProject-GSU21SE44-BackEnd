using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        private readonly DbSet<Activity> _activity;

        public ActivityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _activity = dbContext.Set<Activity>();
        }
    }
}