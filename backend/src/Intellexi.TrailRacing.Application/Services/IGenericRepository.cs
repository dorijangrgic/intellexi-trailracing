using Ardalis.Specification;

namespace Intellexi.TrailRacing.Application.Services;

public interface IGenericRepository<T> 
    : IRepositoryBase<T>
    where T : class
{
}