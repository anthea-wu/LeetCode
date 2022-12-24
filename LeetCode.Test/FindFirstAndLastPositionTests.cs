using System.Collections;

namespace LeetCode.Test;

[TestFixture]
public class FindFirstAndLastPositionTests
{
    [TestCaseSource(nameof(FailedTestCasesData))]
    public void do_second_time_failed(int[] nums, int target)
    {
        var findFirstAndLastPosition = new FindFirstAndLastPosition();
        var result = findFirstAndLastPosition.DoSecondTime(nums, target);
        Assert.AreEqual(-1, result[0]);
        Assert.AreEqual(-1, result[1]);
    }
    
    [TestCaseSource(nameof(SuccessTestCasesData))]
    public void do_second_time_success(int[] nums, int target, int expectedFirstIndex, int expectedSecondIndex)
    {
        var findFirstAndLastPosition = new FindFirstAndLastPosition();
        var result = findFirstAndLastPosition.DoSecondTime(nums, target);
        Assert.AreEqual(expectedFirstIndex, result[0]);
        Assert.AreEqual(expectedSecondIndex, result[1]);
    }
    
    [TestCaseSource(nameof(FailedTestCasesData))]
    public void do_first_time_failed(int[] nums, int target)
    {
        var findFirstAndLastPosition = new FindFirstAndLastPosition();
        var result = findFirstAndLastPosition.Do(nums, target);
        Assert.AreEqual(-1, result[0]);
        Assert.AreEqual(-1, result[1]);
    }
    
    [TestCaseSource(nameof(SuccessTestCasesData))]
    public void do_first_time_success(int[] nums, int target, int expectedFirstIndex, int expectedSecondIndex)
    {
        var findFirstAndLastPosition = new FindFirstAndLastPosition();
        var result = findFirstAndLastPosition.Do(nums, target);
        Assert.AreEqual(expectedFirstIndex, result[0]);
        Assert.AreEqual(expectedSecondIndex, result[1]);
    }

    public static IEnumerable FailedTestCasesData
    {
        get
        {
            yield return new TestCaseData(Array.Empty<int>(), 0);
            yield return new TestCaseData(new[] { 5, 7, 7, 8, 8, 10 }, 6);
        }
    }
    
    public static IEnumerable SuccessTestCasesData
    {
        get
        {
            yield return new TestCaseData(new[] { 5, 7, 7, 8, 8, 10 }, 8, 3, 4);
        }
    }
}