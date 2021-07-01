using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class PregnancyInformationRepository : GenericRepository<PregnancyInfo>, IPregnancyInformationRepository
    {
        private readonly DbSet<PregnancyInfo> _pregnancyInformation;

        public PregnancyInformationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _pregnancyInformation = dbContext.Set<PregnancyInfo>();
        }
    }
}
