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
   
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        private readonly DbSet<Staff> _staff;

        public StaffRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _staff = dbContext.Set<Staff>();
        }
    }
}
