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
    public class NewsMomRepository : GenericRepository<NewsMom>, INewsMomRepository
    {
        private readonly DbSet<NewsMom> _newsMom;

        public NewsMomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _newsMom = dbContext.Set<NewsMom>();
        }
    }
}
