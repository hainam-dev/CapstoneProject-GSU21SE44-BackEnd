using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Infrastucture.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
