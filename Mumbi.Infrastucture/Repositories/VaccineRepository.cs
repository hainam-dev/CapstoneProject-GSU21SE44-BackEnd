using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

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