using Intellexi.TrailRacing.Domain;

namespace Intellexi.TrailRacing.UnitTests.Domain.Fixtures;

internal class UserTestsFixture
{
    protected static IEnumerable<TestCaseData> Create_ShouldThrowArgumentNullException_TestCases()
    {
        yield return new TestCaseData(null, "lastName", "email", DateTime.UtcNow.AddDays(-3), UserRole.Applicant);
        yield return new TestCaseData("firstName", null, "email", DateTime.UtcNow.AddDays(-3), UserRole.Applicant);
        yield return new TestCaseData("firstName", "lastName", null, DateTime.UtcNow.AddDays(-3), UserRole.Applicant);
        yield return new TestCaseData("firstName", "lastName", "email", null, UserRole.Applicant);
    }

    protected static IEnumerable<TestCaseData> Create_ShouldThrowArgumentException_TestCases()
    {
        var longString = new string('a', MaxPropertyLength + 1);

        yield return new TestCaseData(longString, "lastName", "email", DateTime.UtcNow.AddDays(-3), UserRole.Applicant);
        yield return new TestCaseData("firstName", longString, "email", DateTime.UtcNow.AddDays(-3), UserRole.Applicant);
        yield return new TestCaseData("firstName", "lastName", longString, DateTime.UtcNow.AddDays(-3), UserRole.Applicant);
        
        yield return new TestCaseData("firstName", "lastName", "email", DateTime.UtcNow.AddDays(1), UserRole.Applicant);
    }

    protected static IEnumerable<TestCaseData> Create_ShouldThrowInvalidEnumArgumentException_TestCases()
    {
        yield return new TestCaseData("firstName", "lastName", "email", DateTime.UtcNow.AddDays(-3), 3);
    }

    protected static IEnumerable<TestCaseData> Create_ShouldCreateObject_TestCases()
    {
        yield return new TestCaseData("firstName", "lastName", "email", DateTime.UtcNow.AddDays(-3), UserRole.Applicant);
    }
}