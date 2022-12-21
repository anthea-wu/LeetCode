namespace LeetCode;

public class BinarySearch
{
    public int Do(int[] nums, int target)
    {
        var leftIndex = 0;
        var rightIndex = nums.Length - 1;

        while (leftIndex <= rightIndex)
        {
            var middle = (rightIndex - leftIndex) / 2 + leftIndex;

            if (nums[middle] < target)
            {
                leftIndex = middle + 1;
            }
            else if (target < nums[middle])
            {
                rightIndex = middle - 1;
            }
            else
            {
                return middle;
            }
        }
        
        return -1;
    }
}