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
    public class StandardIndexRepository : GenericRepository<StandardIndex>, IStandardIndexRepository
    {
        private readonly DbSet<StandardIndex> _standardIndex;

        public StandardIndexRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _standardIndex = dbContext.Set<StandardIndex>();
        }
    }
}
