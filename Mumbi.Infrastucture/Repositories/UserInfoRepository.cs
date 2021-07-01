using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class UserInfoRepository : GenericRepository<UserInfo>, IUserInfoRepository
    {
        private readonly DbSet<UserInfo> _userInfo;

        public UserInfoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _userInfo = dbContext.Set<UserInfo>();
        }
    }
}
