using System.Collections;
using NUnit.Framework;

namespace LeetCode.Test;

[TestFixture]
public class TwoSumTests
{
    [TestCaseSource(nameof(TwoSumTestCasesData))]
    public void return_correct_index_another_method(int[] input, int target, int firstIndex, int secondIndex)
    {
        var twoSum = new TwoSum();
        var indexes = twoSum.DoAnother(input, target);

        Assert.AreEqual(firstIndex, indexes[0]);
        Assert.AreEqual(secondIndex, indexes[1]);
    }
    
    [TestCaseSource(nameof(TwoSumTestCasesData))]
    public void return_correct_index(int[] input, int target, int firstIndex, int secondIndex)
    {
        var twoSum = new TwoSum();
        var indexes = twoSum.Do(input, target);
        
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