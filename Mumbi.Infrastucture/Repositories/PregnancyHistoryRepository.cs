using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class PregnancyHistoryRepository : GenericRepository<PregnancyHistory>, IPregnancyHistoryRepository
    {
        private readonly DbSet<PregnancyHistory> _pregnancyHistory;

        public PregnancyHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _pregnancyHistory = dbContext.Set<PregnancyHistory>();
        }
    }
}