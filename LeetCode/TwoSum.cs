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

    public int[] DoAnother(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            var remain = target - nums[i];
            var indexOfRemain = Array.IndexOf(nums, remain, i + 1);
            
            if (indexOfRemain >= 0 && indexOfRemain != i)
            {
                return new []{i, indexOfRemain};
            }
        }

        return new int[] { };
    }

    public int[] DoTheOther(int[] nums, int target)
    {
        var usedNums = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var remain = target - nums[i];
            if (usedNums.ContainsKey(remain))
            {
                return new[] { usedNums[remain], i };
            }
            else
            {
                usedNums[nums[i]] = i;
            }
        }
        
        throw new ArgumentException();
    }
}