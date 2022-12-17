namespace LeetCode;

public class TwoSum
{
    public int[] Do(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 0; j < nums.Length; j++)
            {
                if (i == j) continue;

                var sum = nums[i] + nums[j];
                if (sum == target) return new[] { i, j };
            }
        }

        return new int[] { };
    }
}