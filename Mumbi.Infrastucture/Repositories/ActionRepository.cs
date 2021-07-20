using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Infrastucture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
