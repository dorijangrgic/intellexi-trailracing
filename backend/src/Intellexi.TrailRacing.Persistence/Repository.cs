using Ardalis.Specification.EntityFrameworkCore;
using Intellexi.TrailRacing.Application.Services;

namespace Intellexi.TrailRacing.Persistence;

public class Repository<T> 
    : RepositoryBase<T>, IRepository<T>
    where T : class
{
    public Repository(TrailRacingDbContext dbContext) : base(dbContext)
    {
    }
}