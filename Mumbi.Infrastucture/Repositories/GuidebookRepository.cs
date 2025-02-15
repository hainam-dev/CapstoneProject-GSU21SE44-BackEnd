﻿using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class GuidebookRepository : GenericRepository<Guidebook>, IGuidebookRepository
    {
        private readonly DbSet<Guidebook> _guidebook;

        public GuidebookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _guidebook = dbContext.Set<Guidebook>();
        }
    }
}