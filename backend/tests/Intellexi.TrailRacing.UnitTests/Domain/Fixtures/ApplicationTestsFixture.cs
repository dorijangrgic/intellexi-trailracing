namespace Intellexi.TrailRacing.UnitTests.Domain.Fixtures;

internal class ApplicationTestsFixture
{
    protected static IEnumerable<TestCaseData> Create_ShouldThrowArgumentNullException_TestCases()
    {
        yield return new TestCaseData(null, "lastName", "club");
        yield return new TestCaseData("firstName", null, "club");
        yield return new TestCaseData("firstName", "lastName", null);
    }
    
    protected static IEnumerable<TestCaseData> Create_ShouldThrowArgumentException_TestCases()
    {
        var longString = new string('a', MaxPropertyLength + 1);

        yield return new TestCaseData(longString, "lastName", "club");
        yield return new TestCaseData("firstName", longString, "club");
        yield return new TestCaseData("firstName", "lastName", longString);
    }
    
    protected static IEnumerable<TestCaseData> Create_ShouldCreateObject_TestCases()
    {
        yield return new TestCaseData("firstName", "lastName", "club", Guid.NewGuid());
    }
}