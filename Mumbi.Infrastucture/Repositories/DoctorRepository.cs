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
    
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly DbSet<Doctor> _doctor;

        public DoctorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _doctor = dbContext.Set<Doctor>();
        }
    }
}
