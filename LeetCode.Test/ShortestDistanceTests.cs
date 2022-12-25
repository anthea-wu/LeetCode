using System.Collections;

namespace LeetCode.Test;

[TestFixture]
public class ShortestDistanceTests
{
    private ShortestDistance _shortestDistance;

    [SetUp]
    public void SetUp()
    {
        _shortestDistance = new ShortestDistance();
    }

    [TestCaseSource(nameof(ShortestDistanceTestCasesData))]
    public void do_second_time_success(string[] words, string target, int startIndex, int expectedDistance)
    {
        var result = _shortestDistance.DoSecondTime(words, target, startIndex);
        Assert.AreEqual(expectedDistance, result);
    }

    [TestCaseSource(nameof(ShortestDistanceTestCasesData))]
    public void do_success(string[] words, string target, int startIndex, int expectedDistance)
    {
        var result = _shortestDistance.Do(words, target, startIndex);
        Assert.AreEqual(expectedDistance, result);
    }

    public static IEnumerable ShortestDistanceTestCasesData
    {
        get
        {
            yield return new TestCaseData(new[] { "hello", "i", "am", "leetcode", "hello" }, "hello", 1, 1);
            yield return new TestCaseData(new[] { "a", "b", "leetcode" }, "leetcode", 0, 1);
            yield return new TestCaseData(new[] { "i", "eat", "leetcode" }, "ate", 0, -1);
            yield return new TestCaseData(new[]
            {
                "hsdqinnoha", "mqhskgeqzr", "zemkwvqrww", "zemkwvqrww", "daljcrktje", "fghofclnwp", "djwdworyka",
                "cxfpybanhd", "fghofclnwp", "fghofclnwp"
            }, "zemkwvqrww", 8, 4);
            yield return new TestCaseData(new[]
            {
                "pgmiltbptl", "jnkxwutznb", "bmeirwjars", "ugzyaufzzp", "pgmiltbptl", "sfhtxkmzwn", "pgmiltbptl",
                "pgmiltbptl", "onvmgvjhxa", "jyzdtwbwqp"
            }, "pgmiltbptl", 4, 0);
            yield return new TestCaseData(new[]
            {
                "hqrdflmsiv", "bphfkwxwux", "jwhovjrktk", "masvwbrofg", "bpngempqkt", "bphfkwxwux", "bpngempqkt",
                "wvpoegifyu", "bpngempqkt", "wrgdcgwvrx"
            }, "bpngempqkt", 1, 3);
        }
    }
}