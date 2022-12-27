# 69. Sqrt(x)

> Given a non-negative integer `x`, return the square root of `x` rounded down to the nearest integer. The returned integer should be **non-negative** as well.
> 
> You **must not use** any built-in exponent function or operator.
> 
> - For example, do not use `pow(x, 0.5)` in c++ or `x ** 0.5` in python.
> 
> ---
> 
> Example 1:
> ```csharp
> Input: x = 4
> Output: 2
> Explanation: The square root of 4 is 2, so we return 2.
> ```
> ---
> Example 2:
> 
> ```csharp
> Input: x = 8
> Output: 2
> Explanation: The square root of 8 is 2.82842..., and since we round it down to the nearest integer, 2 is returned.
> ```
> ---
> Constraints:
> 
> - `0 <= x <= 2^31 - 1`

## 題解
回傳平方根，如果平方根不是正整數就回傳那個小樹的整數位。

以 Example 2 為例，可以理解成 `2^2 < 8 < 3^3`，所以回傳 `2`。也就是說， 只要 `<= target` 就可以回傳。

## 二分法：兩數相乘

```csharp
var left = 0;
var right = x;
var result = 0;

while(left <= right)
{
    var middle = left + (right - left) / 2;
    if (middle * middle == x)
    {
        // 剛好相等就直接回傳
        return middle;
    }
    else if (middle * middle < x)
    {
        // 小於就存起來，看有沒有更接近的
        result = middle;
        left = ++middle;
    }
    else
    {
        // 大於就繼續跑
        right = --middle;
    }
}

return result;
```

有通過一部分測資，代表思路應該是對的，拿著 Code 回 IDE 跑一遍才發現應該是因為 **兩數相乘** 有可能超過 `int` 的上限，才導致結果怪怪的。

## 超過上限：改用除法
既然用乘的會超過，那就試試用除的吧。用除法要注意的一個細節是：除數不能是 `0`，所以會使除數 `middle` 變成 `0` 的情況要避開：

```csharp
public class Solution {
    public int MySqrt(int x) {
        // 0 和 1 會使 middle  = 0
        if (x <= 1) return x;
        
        var left = 0;
        var right = x;
        var result = 0;
        
        while(left <= right)
        {
            var middle = left + (right - left) / 2;
            if (middle == x / middle)
            {
                return middle;
            }
            else if (middle < x / middle)
            {
                result = middle;
                left = ++middle;
            }
            else
            {
                right = --middle;
            }
        }

        return result;
    }
}
```

## 效能
- Time Complexity: O(log N)
- Space Complexity: O(1)
- Runtime: 20 ms
- Memory Usage: 26.6 MB