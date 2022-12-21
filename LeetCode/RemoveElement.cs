namespace LeetCode;

public class RemoveElement
{
    public int DoFirstTime(int[] nums, int val)
    {
        var size = nums.Length;
        for (var i = 0; i < size; i++)
        {
            if (nums[i] == val)
            {
                for (var j = i + 1; j < size; j++)
                {
                    nums[j - 1] = nums[j];
                }

                i--;
                size--;
            }
        }

        return size;
    }
}