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
    public class VaccineRepository : GenericRepository<Vaccine>, IVaccineRepository
    {
        private readonly DbSet<Vaccine> _vaccine;

        public VaccineRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _vaccine = dbContext.Set<Vaccine>();
        }
    }
}
