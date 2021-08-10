using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly DbSet<Role> _role;

        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _role = dbContext.Set<Role>();
        }
    }
}