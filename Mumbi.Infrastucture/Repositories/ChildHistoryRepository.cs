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
    public class ChildHistoryRepository : GenericRepository<ChildHistory>, IChildHistoryRepository
    {
        private readonly DbSet<ChildHistory> _childHistory;

        public ChildHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _childHistory = dbContext.Set<ChildHistory>();
        }
    }
}
