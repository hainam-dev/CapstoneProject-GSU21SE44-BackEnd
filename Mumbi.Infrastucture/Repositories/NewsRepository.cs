using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

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