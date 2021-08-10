using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class NewsTypeRepository : GenericRepository<NewsType>, INewsTypeRepository
    {
        private readonly DbSet<NewsType> _newsType;

        public NewsTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _newsType = dbContext.Set<NewsType>();
        }
    }
}