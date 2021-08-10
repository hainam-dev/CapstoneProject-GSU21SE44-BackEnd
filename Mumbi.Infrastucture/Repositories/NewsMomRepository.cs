using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class NewsMomRepository : GenericRepository<NewsMom>, INewsMomRepository
    {
        private readonly DbSet<NewsMom> _newsMom;

        public NewsMomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _newsMom = dbContext.Set<NewsMom>();
        }
    }
}