using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Infrastucture.Repositories
{
   
    public class TokenRepository : GenericRepository<Token>, ITokenRepository
    {
        private readonly DbSet<Child> _token;

        public TokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _token = dbContext.Set<Token>();
        }
    }
}
