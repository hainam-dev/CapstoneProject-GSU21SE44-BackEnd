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
    public class ActionChildRepository : GenericRepository<ActionChild>, IActionChildRepository
    {
        private readonly DbSet<ActionChild> _actionChild;

        public ActionChildRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _actionChild = dbContext.Set<ActionChild>();
        }
    }
}
