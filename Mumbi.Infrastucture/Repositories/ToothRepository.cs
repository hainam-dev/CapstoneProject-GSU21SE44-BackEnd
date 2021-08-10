using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class ToothRepository : GenericRepository<Tooth>, IToothRepository
    {
        private readonly DbSet<Tooth> _tooth;

        public ToothRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _tooth = dbContext.Set<Tooth>();
        }
    }
}