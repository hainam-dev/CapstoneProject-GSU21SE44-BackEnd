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
    public class GuidebookTypeRepository : GenericRepository<GuidebookType>, IGuidebookTypeRepository
    {
        private readonly DbSet<GuidebookType> _guidebookType;

        public GuidebookTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _guidebookType = dbContext.Set<GuidebookType>();
        }
    }
}
