using Ardalis.Specification;

namespace Intellexi.TrailRacing.Application.Services;

public interface IRepository<T> 
    : IRepositoryBase<T>
    where T : class
{
}