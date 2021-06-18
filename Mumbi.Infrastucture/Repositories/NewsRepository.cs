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
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        private readonly DbSet<News> _news;

        public NewsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _news = dbContext.Set<News>();
        }
    }
}
