# 2520. Count the Digits That Divide a Number
> Given an integer `num`, return the number of digits in `num` that divide `num`.
> 
> An integer `val` divides nums if `nums % val == 0`.
> 
> ---
> Example 1:
> ```csharp
> Input: num = 7
> Output: 1
> Explanation: 7 divides itself, hence the answer is 1.
> ```
> Example 2:
> ```csharp
> Input: num = 121
> Output: 2
> Explanation: 121 is divisible by 1, but not 2. Since 1 occurs twice as a digit, we return 2.
> ```
> Example 3:
> ```csharp
> Input: num = 1248
> Output: 4
> Explanation: 1248 is divisible by all of its digits, hence the answer is 4.
> ```
> ---
> Constraints:
> 
> 1. `1 <= num <= 10^9`
> 2. `num` does not contain `0` as one of its digits.

## 題解
Weekly Contest 326，Easy。

給一組數字，分解成一個一個數字，找出可以整除原本數字的數量。

```csharp
var num = 12345;
// 數字：      [1, 2, 3, 4, 5]
// 可以被整除： [O, X, O, X, O] => return 3
```

## 最佳解
把原本的 int 變成可以跑 for 或 foreach 的物件，一個一個比對就行。

```csharp
var count = 0;
var nums = num.ToString();

foreach (var n in nums)
{
    var current = Convert.ToInt32(n.ToString());
    
    if (current == 0)
    {
        // 除數不能是 0
        continue;
    }

    if (num % current == 0)
    {
        count++;
    }
}

return count;
```

## 效能
- Time complexity: `O(n)`
- Space complexity: `O(n)`
- Runtime: 17 ms
- Memory: 26.6 MB