using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
