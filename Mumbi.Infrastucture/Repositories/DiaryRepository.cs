using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class DiaryRepository : GenericRepository<Diary>, IDiaryRepository
    {
        private readonly DbSet<Diary> _diary;

        public DiaryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _diary = dbContext.Set<Diary>();
        }
    }
}