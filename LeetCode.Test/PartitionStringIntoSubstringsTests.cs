using System.Collections;
using NUnit.Framework;

namespace LeetCode.Test;

[TestFixture]
public class PartitionStringIntoSubstringsTests
{
    [TestCaseSource(nameof(TestCasesData))]
    public void do_success(string s, int k, int expected)
    {
        var partitionStringIntoSubstrings = new PartitionStringIntoSubstrings();
        var result = partitionStringIntoSubstrings.Do(s, k);
        Assert.AreEqual(expected, result);
    }

    public static IEnumerable TestCasesData
    {
        get
        {
            yield return new TestCaseData("165462", 60, 4);
            yield return new TestCaseData("238182", 5, -1);
            yield return new TestCaseData("1", 1, 1);
            yield return new TestCaseData("75734379996162298577", 7, -1);
        }
    }
}