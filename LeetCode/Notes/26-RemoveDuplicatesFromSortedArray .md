# 26. Remove Duplicates from Sorted Array
> Given an integer array `nums` sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same.
> 
> Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array `nums`. More formally, if there are `k` elements after removing the duplicates, then the first `k` elements of nums should hold the final result. It does not matter what you leave beyond the first `k` elements.
> 
> Return `k` after placing the final result in the first `k` slots of `nums`.
> 
> Do not allocate extra space for another array. You must do this by modifying the input array in-place with `O(1)` extra memory.
> 
> ---
> Example 1:
> ```csharp
> Input: nums = [1,1,2]
> Output: 2, nums = [1,2,_]
> Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
> It does not matter what you leave beyond the returned k (hence they are underscores).
> ```
> Example 2:
> ```csharp
> Input: nums = [0,0,1,1,1,2,2,3,3,4]
> Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
> Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
> It does not matter what you leave beyond the returned k (hence they are underscores).
> ```
> ---
> Constraints:
> 
> 1. `1 <= nums.length <= 3 * 10<sup>4</sup>`
> 1. `-100 <= nums[i] <= 100`
> 1. `nums` is sorted in **non-decreasing** order.

## 快慢指針
相關基礎題目：[27. Remove Element](https://leetcode.com/problems/remove-element/description/)

這題一樣預先知道是快慢指針的關聯題，所以用快慢指針去想。根據[代碼隨想錄](https://github.com/youngyangyang04/leetcode-master/blob/master/problems/0027.%E7%A7%BB%E9%99%A4%E5%85%83%E7%B4%A0.md)的定義，快指針要找預期 Array 的元素索引，慢指針則是待更新的索引。

套用到這題上，會發現問題是：沒有一個預設固定的目標可以比對，無法直接套用快慢指針。

來看一下 Example 2：

```csharp
nums = [0,0,1,1,1,2,2,3,3,4]
```

這個例子中，每個區間要比對的目標都不一樣：

```csharp
nums = [0,0,1,1,1,2,2,3,3,4]
        ^ ^ ------------------ 比對目標：0
            ^ ^ ^ ------------ 比對目標：1
                  ^ ^ -------- 比對目標：2
                      ^ ^ ---- 比對目標：3
```

先來看一下基本的快慢指針：
```csharp
var slowIndex = 0;
for (var fastIndex = 0; fastIndex < nums.Length; fastIndex++)
{
    if (target != nums[fastIndex]){
        nums[slowIndex] = nums[fastIndex];
        slowIndex++;
    }
}
```

接下來要指定我們的比對目標 `target`。題目的條件中有說到， `nums` 會在 -100~100 之間，所以我們把 `target` 設定成一個不在區間內的數字：

```csharp
public int RemoveDuplicates(int[] nums) {
    var target = -999;
    var slowIndex = 0;
    for (var fastIndex = 0; fastIndex < nums.Length; fastIndex++)
    {
        if (target != nums[fastIndex]){
            // target != nums[fastIndex] 代表沒有重複的數字了
            // 所以要把 target 換成下一個要比對的數字
            target = nums[fastIndex];
            
            nums[slowIndex] = nums[fastIndex];
            slowIndex++;
        }
    }

    return slowIndex;
}
```

### 如果 target 在 array 區間內

```csharp
// nums = [1,1,2]
public int RemoveDuplicates(int[] nums) {
    var target = 1;
    var slowIndex = 0;
    for (var fastIndex = 0; fastIndex < nums.Length; fastIndex++)
    {
        // fastIndex = 0 - target == nums[fastIndex]
        // fastIndex = 1 - target == nums[fastIndex]
        // fastIndex = 2 - target != nums[fastIndex] => nums = [2,1,2], slowIndex = 1
        if (target != nums[fastIndex]){
            target = nums[fastIndex];
            nums[slowIndex] = nums[fastIndex];
            slowIndex++;
        }
    }

    return slowIndex;
}
```
## 完整程式碼
考慮到 `nums = [1]` 的時候不可能重複，以及 `nums = []` 的情況，加上一個 if 條件，完整的程式碼如下：

```csharp
public int RemoveDuplicates(int[] nums) {
    if (nums.Length <= 1)
    {
        return nums.Length;
    }

    var target = -999;
    var slowIndex = 0;
    for (var fastIndex = 0; fastIndex < nums.Length; fastIndex++)
    {
        if (target != nums[fastIndex]){
            target = nums[fastIndex];
            nums[slowIndex] = nums[fastIndex];
            slowIndex++;
        }
    }

    return slowIndex;
}
```

## 效能
- Time Complexity: O(N)
- Space Complexity: O(1)
- Runtime: 160 ms
- Memory Usage: 46.4 MB