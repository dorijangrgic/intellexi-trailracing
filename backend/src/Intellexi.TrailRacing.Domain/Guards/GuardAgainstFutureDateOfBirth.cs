using Ardalis.GuardClauses;

namespace Intellexi.TrailRacing.Domain.Guards;

public static class GuardAgainstFutureDateOfBirth
{
    public static void FutureDateOfBirth(
        this IGuardClause _,
        DateTime dateOfBirth,
        TimeProvider timeProvider)
    {
        if (dateOfBirth >= timeProvider.GetUtcNow())
        {
            throw new ArgumentException($"Date of birth [{dateOfBirth}] cannot be in the future.");
        }
    }
}