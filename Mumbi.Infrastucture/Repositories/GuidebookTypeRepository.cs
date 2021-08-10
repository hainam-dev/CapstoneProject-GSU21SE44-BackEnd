using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class GuidebookTypeRepository : GenericRepository<GuidebookType>, IGuidebookTypeRepository
    {
        private readonly DbSet<GuidebookType> _guidebookType;

        public GuidebookTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _guidebookType = dbContext.Set<GuidebookType>();
        }
    }
}