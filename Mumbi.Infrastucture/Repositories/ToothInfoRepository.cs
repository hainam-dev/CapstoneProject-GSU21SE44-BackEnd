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
    public class ToothInfoRepository : GenericRepository<ToothInfo>, IToothInfoRepository
    {
        private readonly DbSet<ToothInfo> _toothInfo;

        public ToothInfoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _toothInfo = dbContext.Set<ToothInfo>();
        }
    }
}
