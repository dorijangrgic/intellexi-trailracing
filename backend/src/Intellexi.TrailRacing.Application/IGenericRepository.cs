using Ardalis.Specification;

namespace Intellexi.TrailRacing.Application;

public interface IGenericRepository<T> 
    : IRepositoryBase<T>
    where T : class
{
}