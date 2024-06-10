using Ardalis.GuardClauses;

namespace Intellexi.TrailRacing.Application.Common;

public static class GuardAgainstEntityNotFound
{
    public static void EntityNotFound<T, TId>(
        this IGuardClause _,
        T entity,
        TId id) where T : class
    {
        if (entity is not null) return;

        throw new ErrorHandling.Exceptions.NotFoundException(
            string.Format(ErrorMessages.EntityNotFound, typeof(T).Name, id));
    }
}