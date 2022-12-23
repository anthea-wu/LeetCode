using System.Collections;

namespace LeetCode.Test;

[TestFixture]
public class SearchInsertPositionTests
{
    [TestCaseSource(nameof(SearchInsertPositionTestCasesData))]
    public void do_first_time(int[] nums, int target, int expectedIndex)
    {
        var searchInsertPosition = new SearchInsertPosition();
        var result = searchInsertPosition.DoFirstTime(nums, target);
        Assert.AreEqual(expectedIndex, result);
    }

    public static IEnumerable SearchInsertPositionTestCasesData
    {
        get
        {
            yield return new TestCaseData(new[] { 1, 3, 5, 6 }, 5, 2);
            yield return new TestCaseData(new[] { 1, 3, 5, 6 }, 2, 1);
            yield return new TestCaseData(new[] { 1, 3, 5, 6 }, 7, 4);
            yield return new TestCaseData(new[] { 1, 3 }, 2, 1);  // 想了 35 分鐘，卡在這裡
        }
    }
}