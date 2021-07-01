using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;


namespace Mumbi.Infrastucture.Repositories
{
    public class DadRepository : GenericRepository<DadInfo>, IDadRepository
    {
        private readonly DbSet<DadInfo> _dad;

        public DadRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dad = dbContext.Set<DadInfo>();
        }
    }
}
