# 34. Find First and Last Position of Element in Sorted Array

> Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.
> 
> If target is not found in the array, return [-1, -1].
> 
> You must write an algorithm with O(log n) runtime complexity.
> 
> ---
> Example 1:
> ```csharp
> Input: nums = [5,7,7,8,8,10], target = 8
> Output: [3,4]
> ``` 
> Example 2:
> ```csharp
> Input: nums = [5,7,7,8,8,10], target = 6
> Output: [-1,-1]
> ``` 
> Example 3:
> ```csharp
> Input: nums = [], target = 0
> Output: [-1,-1]
> ``` 
> ---
> Constraints:
> 
> 1. `0 <= nums.length <= 10<sup>5</sup>`
> 2. `-10<sup>9</sup> <= nums[i] <= <sup>9</sup>`
> 3. `nums` is a non-decreasing array.
> 4. `-10<sup>9</sup> <= target <= 10<sup>9</sup>`

## 直覺
Binary Search 的延伸題，試著用迴圈跑：

```csharp
while (leftIndex <= rightIndex)
{
    // run 1
    // middleIndex = 3
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
        // nums[middleIndex] = 8
        // target = 8
    }
}
```

在 Example 1 中先找到的是 `nums[3]` 的 8，他剛好會是 target 開始的索引位置；但如果今天把資料換成：

```csharp
[5,7,8,8,9,10], target = 6
```

這時候先找到的 `nums[3]` 的 8，反而是 target 結束的索引位置。到這邊就卡住了，因為需要區分開始和結束的索引位置，但沒有想到辦法判斷目前找到的是開始還是結束位置。

## 解法：分開找開始和結束的索引位置

首先先找開始的索引位置。一樣進行基本的 Binary Search，定義我們最後要找的開始索引 `startIndex = -1`，假設我們沒找到的話就可以直接回傳 -1。

```csharp
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
```

在 Example 1 中，第一個 while 中：
```csharp
nums = [5, 7, 7, 8, 8, 10]
leftIndex = 0
rightIndex = 5
middleIndex = 0 + (5 - 0) / 2 = 3
target = 8 = nums[middleIndex]
```

找到了第一個和 `target` 相符的索引位置，所以可以把它當成開始的索引位置。既然他是開始的位置，他就必須比結束位置還要左邊。如果今天在 `index = 3` 左邊，也就是 `index` 在 0~2 之間還有數字 8 存在的話，代表開始索引應該會再往左移。

```csharp
5 7 8 8 8 10
0 1 2 3 4 5
    ^ ^
    o x
```

所以接下來要確認整個 nums 更左邊的地方，還有沒有可以當開始位置的索引存在，因此要把整個查詢的位置往左移：
```csharp
// run 1
5 7 7 8 8 10
0 1 2 3 4 5
      ^
startIndex = 3

// run 2
5 7 7
0 1 2
startIndex = 3 ( return )
```

### 找結束的索引位置
學會如何找開始的索引位置，找結束的就很簡單，只要把邏輯換成：確認右邊有沒有還可以當結束位置的索引存在即可。

```csharp
5 7 7 8 8 10
0 1 2 3 4 5
      ^ ^
      x o
```

### 完整程式碼

```csharp
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
```

## 效能
- Time Complexity: O(N)
- Space Complexity: O(1)
- Runtime: 267 ms
- Memory Usage: 43.4 MB