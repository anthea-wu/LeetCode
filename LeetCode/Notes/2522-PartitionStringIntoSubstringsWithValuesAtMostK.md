# 2522. Partition String Into Substrings With Values at Most K

> You are given a string `s` consisting of digits from `1` to `9` and an integer `k`.
> 
> A partition of a string `s` is called **good** if:
> 
> - Each digit of `s` is part of **exactly** one substring.
> - The value of each substring is less than or equal to `k`.
> 
> Return the **minimum** number of substrings in a **good** partition of `s`. If no **good** partition of `s` exists, return `-1`.
> 
> Note that:
> 
> - The **value** of a string is its result when interpreted as an integer. For example, the value of `"123"` is `123` and the value of `"1"` is `1`.
> - A **substring** is a contiguous sequence of characters within a string.
> 
> 
> ---
> Example 1:
> ```csharp
> Input: s = "165462", k = 60
> Output: 4
> Explanation: We can partition the string into substrings "16", "54", "6", and "2". Each substring has a value less than or equal to k = 60.
> It can be shown that we cannot partition the string into less than 4 substrings.
> ```
> Example 2:
> ```csharp
> Input: s = "238182", k = 5
> Output: -1
> Explanation: There is no good partition for this string.
> ```
> 
> ---
> Constraints:
> 
> 1. `1 <= s.length <= 10^5`
> 2. `s[i]` is a digit from `'1'` to `'9'`.
> 3. `1 <= k <= 10^9`

## 題解

Weekly Contest 326，Medium。

給定一組字串和一個指定的數字，將指定的數字當作上限，把字串分割成小於指定數字的子字串，回傳子字串數量。
```csharp
var s = "165462";
var k = 60;

// 可以分割成：[16, 54, 6, 2]
return 4;
```

如果有超過指定數字的子字串，回傳 `-1`：
```csharp
var s = "238182";
var k = 5;

// 8 > 5
return -1;
```

## 滑動視窗
這題給我的感覺滿像滑動視窗的，都需要找一個區間出來做比較，超過就做一些處理。重點會放在：
1. 定義視窗區間的開始和結束
2. 超過時要如何重製區間的開始和結束

嘗試過用 `startIndex` 和 `endIndex` 來理解這個題目，搭配 `s.Substring()` 來找出區間，但在邏輯上對於區間總和超過 `k` 時，要如何重製 `startIndex` 和 `endIndex` 有點混亂。

但其實這題不需要特別指定 `startIndex` 和 `endIndex` 也可以達成：

```csharp
// 區間
var substring = "";

// for 迴圈不包括最後一個區間
var result = 1;

foreach (var item in s)
{
    // char 可以被轉換成 ASCII Code 做計算
    // 以 Examplet 2 為例
    // k = 5，如果 item > k(5) 就代表超過指定數字
    // 回傳 -1
    if (item - '0' > k) return -1;

    // 把數字加入新的區間
    substring += item;

    // 要注意測資的指定大小來決定 Convert 的目標
    if (Convert.ToDouble(substring) > k)
    {
        // 如果區間的數字大於 k
        // 代表在這之前的區間是合法的子字串
        result++;
        
        // 更新區間為目前的數字
        substring = item.ToString();
    }
}

return result;
```

## 效能
- Time complexity: `O(n)`
- Space complexity: `O(n)`
- Runtime: 145 ms
- Memory: 52 MB