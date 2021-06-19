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
    
    public class GuidebookRepository : GenericRepository<Guidebook>, IGuidebookRepository
    {
        private readonly DbSet<Guidebook> _guidebook;

        public GuidebookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _guidebook = dbContext.Set<Guidebook>();
        }
    }
}
