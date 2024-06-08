using Intellexi.TrailRacing.Domain;

namespace Intellexi.TrailRacing.UnitTests.Domain.Fixtures;

internal class RaceTestsFixture
{
    protected static IEnumerable<TestCaseData> Create_ShouldThrowArgumentNullException_TestCases()
    {
        yield return new TestCaseData(null, RaceDistance.HalfMarathon);
    }
    
    protected static IEnumerable<TestCaseData> Create_ShouldThrowArgumentException_TestCases()
    {
        var longString = new string('a', MaxPropertyLength + 1);

        yield return new TestCaseData(longString, RaceDistance.HalfMarathon);
    }

    protected static IEnumerable<TestCaseData> Create_ShouldThrowInvalidEnumArgumentException_TestCases()
    {
        yield return new TestCaseData("raceName", 10);
    }
    
    protected static IEnumerable<TestCaseData> Create_ShouldCreateObject_TestCases()
    {
        yield return new TestCaseData("raceName", RaceDistance.HalfMarathon);
    }

    protected static IEnumerable<TestCaseData> Update_ShouldThrowArgumentNullException_TestCases()
    {
        yield return new TestCaseData(null, RaceDistance.HalfMarathon);
    }
    
    protected static IEnumerable<TestCaseData> Update_ShouldThrowArgumentException_TestCases()
    {
        var longString = new string('a', MaxPropertyLength + 1);

        yield return new TestCaseData(longString, RaceDistance.HalfMarathon);
    }

    protected static IEnumerable<TestCaseData> Update_ShouldThrowInvalidEnumArgumentException_TestCases()
    {
        yield return new TestCaseData("raceName", 10);
    }
    
    protected static IEnumerable<TestCaseData> Update_ShouldUpdateObject_TestCases()
    {
        yield return new TestCaseData("raceName", RaceDistance.HalfMarathon);
    }
}