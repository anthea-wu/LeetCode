# 1. Two Sum
> Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
> 
> You may assume that each input would have exactly one solution, and you may not use the same element twice.
>
>You can return the answer in any order.
> 
> ---
> Example 1:
> ```
> Input: nums = [2,7,11,15], target = 9
> Output: [0,1]
> ```
>
> Example 2:
> ```
> Input: nums = [3,2,4], target = 6
> Output: [1,2]
> ```
> Example 3:
> ```
> Input: nums = [3,3], target = 6
> Output: [0,1]
> ```
> 
> ---
> Constraints:
> 
> 1. `2 <= nums.length <= 10^4`
> 2. `-10^9 <= nums[i] <= 10^9`
> 3. `-10^9 <= target <= 10^9`
> 4. Only one valid answer exists.

## 直覺

兩個 for 迴圈，加起來相等就回傳（不能自己加自己）。

```csharp
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
```

結果 - `Runtime 210 ms / Memory 44.1 MB`

## 調整迴圈數量

兩個迴圈的做法是用兩個變數相加，一個迴圈就只會有一個變數 `nums[i]` 可以利用，也就是說會變成：

```
sum = nums[i] + unknown
```

而我們的目標是要找出兩個數字相加等於 `target`，現在有第一個可能的數字 `nums[i]` 了，第二個數字就是 `unknown`。從上面可以看出來：

```
unknown = sum - nums[i]
```

而 `sum == target` 是我們的條件，所以可以改寫成：

```
unknown = target - nums[i]
```

這樣就解掉一個迴圈了。於是我們只要去比對 `unkown` 是否存在於 `nums` 中，是的話就找出他的 `index` 即可。程式碼就會變成：

```csharp
for (var i = 0; i < nums.Length; i++)
{
var remain = target - nums[i];
var indexOfRemain = Array.IndexOf(nums, remain);

    if (indexOfRemain >= 0 && indexOfRemain != i)
    {
        return new []{i, indexOfRemain};
    }
}

return new int[] { };
```

結果 - `Runtime 190 ms / Memory 44.1 MB`

## 改變被搜尋物件

`Dictionary` 在執行搜尋的時候會比較快，改成用 `Dictionary` 接搜尋過的數字 `Key` 和他的索引 `Value`，如果還沒找過這個數字就加到 `Dictionary` 內，如果有找過，也就是這個 `Key` 存在於 `Dictionary` 內，就把他的 `Value`，也就是索引抓出來回傳：

```csharp
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
```

結果 - `Runtime 149 ms / Memory 44.8 MB`