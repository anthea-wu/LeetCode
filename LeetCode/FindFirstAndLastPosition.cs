namespace LeetCode;

public class FindFirstAndLastPosition
{
    public int[] Do(int[] nums, int target)
    {
        var rightBorder = GetRightBorder(nums, target);
        var leftBorder = GetLeftBorder(nums, target);
        
        if (rightBorder == -999 || leftBorder == -999) return new[] { -1, -1 };
        if (rightBorder > leftBorder) return new[] { leftBorder + 1, rightBorder - 1 };

        return new[] { -1, -1 };
    }

    private int GetLeftBorder(int[] nums, int target)
    {
        var leftIndex = 0;
        var rightIndex = nums.Length - 1;
        var leftBorder = -999;

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
                rightIndex = middleIndex - 1;
                leftBorder = rightIndex;
            }
        }

        return leftBorder;
    }

    private int GetRightBorder(int[] nums, int target)
    {
        var leftIndex = 0;
        var rightIndex = nums.Length - 1;
        var rightBorder = -999;

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
                leftIndex = middleIndex + 1;
                rightBorder = leftIndex;
            }
        }

        return rightBorder;
    }

    public int[] DoSecondTime(int[] nums, int target)
    {
        var result = new[] { -1, -1 };

        if (nums == null || nums.Length == 0) return result;
        result[0] = GetStartIndex(nums, target);
        result[1] = GetEndIndex(nums, target);

        return result;
    }

    private int GetEndIndex(int[] nums, int target)
    {
        var leftIndex = 0;
        var rightIndex = nums.Length - 1;
        var endIndex = -1;

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
                endIndex = middleIndex;
                leftIndex = middleIndex + 1;
            }
        }
        
        return endIndex;
    }

    private int GetStartIndex(int[] nums, int target)
    {
        var leftIndex = 0;
        var rightIndex = nums.Length - 1;
        var startIndex = -1;

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
                startIndex = middleIndex;
                rightIndex = middleIndex - 1;
            }
        }
        
        return startIndex;
    }
}