using System.Collections;

namespace LeetCode.Test;

[TestFixture]
public class RemoveElementTests
{
    private RemoveElement _removeElement;

    [SetUp]
    public void Setup()
    {
        _removeElement = new RemoveElement();
    }

    [TestCaseSource(nameof(DoFirstTimeTestCasesData))]
    public void do_first_time_success(int[] nums, int val, int[] expected)
    {
        var result = _removeElement.DoFirstTime(nums, val);
        
        Assert.AreEqual(expected.Length, result);
        for (var i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], nums[i]);            
        }
    }

    public static IEnumerable DoFirstTimeTestCasesData
    {
        get
        {
            yield return new TestCaseData(new int[] { 3, 2, 2, 3 }, 3, new int[] { 2, 2 });
            yield return new TestCaseData(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, new int[] { 0, 1, 3, 0, 4 });
        }
    }
}