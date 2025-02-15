﻿using Microsoft.EntityFrameworkCore;
using Mumbi.Application.Interfaces.Repositories;
using Mumbi.Domain.Entities;
using Mumbi.Infrastucture.Context;

namespace Mumbi.Infrastucture.Repositories
{
    public class GuidebookMomRepository : GenericRepository<GuidebookMom>, IGuidebookMomRepository
    {
        private readonly DbSet<GuidebookMom> _guidebookMom;

        public GuidebookMomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _guidebookMom = dbContext.Set<GuidebookMom>();
        }
    }
}