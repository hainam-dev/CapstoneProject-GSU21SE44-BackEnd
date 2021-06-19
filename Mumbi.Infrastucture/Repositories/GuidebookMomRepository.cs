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
    public class GuidebookMomRepository : GenericRepository<GuidebookMom>, IGuidebookMomRepository
    {
        private readonly DbSet<GuidebookMom> _guidebookMom;

        public GuidebookMomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _guidebookMom = dbContext.Set<GuidebookMom>();
        }
    }
}
