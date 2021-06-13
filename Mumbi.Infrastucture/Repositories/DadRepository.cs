using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;


namespace Mumbi.Infrastucture.Repositories
{
    public class DadRepository : GenericRepository<Dad>, IDadRepository
    {
        private readonly DbSet<Dad> _dad;

        public DadRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dad = dbContext.Set<Dad>();
        }
    }
}
