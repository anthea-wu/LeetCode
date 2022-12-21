using System.Collections;

namespace LeetCode.Test;

[TestFixture]
public class BinarySearchTests
{
    [TestCaseSource(nameof(DoSearchSuccessTestCasesData))]
    public void do_search_success(int[] nums, int target, int expected)
    {
        var binarySearch = new BinarySearch();

        var result = binarySearch.Do(nums, target);

        Assert.AreEqual(expected, result);
    }

    public static IEnumerable DoSearchSuccessTestCasesData
    {
        get
        {
            yield return new TestCaseData(new[] { -1, 0, 3, 5, 9, 12 }, 9, 4);
            yield return new TestCaseData(new[] { -1, 0, 3, 5, 9, 12 }, 2, -1);
            yield return new TestCaseData(new[] { -1, 0, 3, 5, 9, 12 }, 12, 5);
            yield return new TestCaseData(new[] { -1, 0, 3, 5, 9, 12 }, -1, 0);
        }
    }
}