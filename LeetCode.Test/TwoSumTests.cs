using System.Collections;
using NUnit.Framework;

namespace LeetCode.Test;

[TestFixture]
public class TwoSumTests
{
    [TestCaseSource(nameof(TwoSumTestCasesData))]
    public void return_correct_index(int[] input, int target)
    {
        var twoSum = new TwoSum();
        var indexes = twoSum.Do(input, target);
        
        Assert.AreEqual(target, input[indexes[0]] + input[indexes[1]]);
    }

    public static IEnumerable TwoSumTestCasesData
    {
        get
        {
            yield return new TestCaseData(new[]{2,7,11,15}, 9);
            yield return new TestCaseData(new[]{3,2,4}, 6);
            yield return new TestCaseData(new[]{3,3}, 6);
        }
    }
}