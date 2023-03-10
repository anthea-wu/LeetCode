using System.Collections;
using NUnit.Framework;

namespace LeetCode.Test;

[TestFixture]
public class TwoSumTests
{
    private TwoSum _twoSum;

    [SetUp]
    public void Setup()
    {
        _twoSum = new TwoSum();
    }

    [TestCaseSource(nameof(TwoSumTestCasesData))]
    public void return_correct_index_when_do_the_other_method(int[] input, int target, int firstIndex, int secondIndex)
    {
        var indexes = _twoSum.DoTheOther(input, target);

        Assert.AreEqual(firstIndex, indexes[0]);
        Assert.AreEqual(secondIndex, indexes[1]);
    }

    [TestCaseSource(nameof(TwoSumTestCasesData))]
    public void return_correct_index_another_method(int[] input, int target, int firstIndex, int secondIndex)
    {
        var indexes = _twoSum.DoAnother(input, target);

        Assert.AreEqual(firstIndex, indexes[0]);
        Assert.AreEqual(secondIndex, indexes[1]);
    }
    
    [TestCaseSource(nameof(TwoSumTestCasesData))]
    public void return_correct_index(int[] input, int target, int firstIndex, int secondIndex)
    {
        var indexes = _twoSum.Do(input, target);
        
        Assert.AreEqual(firstIndex, indexes[0]);
        Assert.AreEqual(secondIndex, indexes[1]);
    }

    public static IEnumerable TwoSumTestCasesData
    {
        get
        {
            yield return new TestCaseData(new[]{2,7,11,15}, 9, 0, 1);
            yield return new TestCaseData(new[]{3,2,4}, 6, 1, 2);
            yield return new TestCaseData(new[]{3,3}, 6, 0, 1);
        }
    }
}