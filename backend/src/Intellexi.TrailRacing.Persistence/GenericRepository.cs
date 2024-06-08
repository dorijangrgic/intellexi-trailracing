﻿using Ardalis.Specification.EntityFrameworkCore;
using Intellexi.TrailRacing.Application;
using Microsoft.EntityFrameworkCore;

namespace Intellexi.TrailRacing.Persistence;

public class GenericRepository<T> 
    : RepositoryBase<T>, IGenericRepository<T>
    where T : class
{
    public GenericRepository(DbContext dbContext) : base(dbContext)
    {
    }
}