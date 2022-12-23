namespace LeetCode;

public class SearchInsertPosition
{
    public int DoFirstTime(int[] nums, int target)
    {
        var leftIndex = 0;
        var rightIndex = nums.Length - 1;

        while (leftIndex <= rightIndex)
        {
            var middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

            if (target < nums[middleIndex])
            {
                rightIndex = middleIndex - 1;
            }
            else if (target > nums[middleIndex])
            {
                leftIndex = middleIndex + 1;
            }
            else
            {
                return middleIndex;
            }
        }

        return leftIndex;
    }
}