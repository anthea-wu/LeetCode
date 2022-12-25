> You are given a 0-indexed circular string array `words` and a string `target`. A circular array means that the array's end connects to the array's beginning.
> 
> - Formally, the next element of `words[i]` is `words[(i + 1) % n]` and the previous element of `words[i]` is `words[(i - 1 + n) % n]`, where `n` is the length of `words`.
> 
> Starting from `startIndex`, you can move to either the next word or the previous word with `1` step at a time.
> 
> Return _the **shortest** distance needed to reach the string_ `target`. If the string `target` does not exist in `words`, return `-1`.
> 
> ---
> 
> Example 1:
> ```csharp
> Input: words = ["hello","i","am","leetcode","hello"], target = "hello", startIndex = 1
> Output: 1
> Explanation: We start from index 1 and can reach "hello" by
> - moving 3 units to the right to reach index 4.
> - moving 2 units to the left to reach index 4.
> - moving 4 units to the right to reach index 0.
> - moving 1 unit to the left to reach index 0.
>   The shortest distance to reach "hello" is 1.
> ```
> 
> Example 2:
> ```csharp
> Input: words = ["a","b","leetcode"], target = "leetcode", startIndex = 0
> Output: 1
> Explanation: We start from index 0 and can reach "leetcode" by
> - moving 2 units to the right to reach index 3.
> - moving 1 unit to the left to reach index 3.
>   The shortest distance to reach "leetcode" is 1.
> ```
> 
> Example 3:
>
> ```csharp
> Input: words = ["i","eat","leetcode"], target = "ate", startIndex = 0
> Output: -1
> Explanation: Since "ate" does not exist in words, we return -1.
> ```
> 
> ---
> **Constraints**:
> 
> 1. `1 <= words.length <= 100`
> 2. `1 <= words[i].length <= 100`
> 3. `words[i]` and `target` consist of only lowercase English letters.
> 4. `0 <= startIndex < words.length`

## 題解
Weekly Contest 325 第一題。

給定一個起始點，往前或往後找到 `target` 字串的最短距離；`words` 頭尾相接，如果 `Index < 0` 會回到陣列最右邊往回找。

## 左右一起找
> 感謝男友大人的提示  

以起始點索引位置為基準，每次走一格，也就是 `startIndex + 1` 和 `startIndex - 1`，看是否有找到 `target`，有舊回傳，沒有就繼續找。

因為頭尾可以相接，所以最大的距離會是長度的一半：從右邊走超過一半的話，其實改成從左邊走會比較近。

```csharp
hello i am leetcode yeah
        ^

hello i am leetcode yeah
     < <
     2 1

hello i am leetcode yeah hello
          >        >    >
          1        2    3 = 5 / 2
```

也就是說，可能的情境有：
1. 起始位置本身就是 `target` - 回傳 `0`
2. 找不到 `target` - 回傳 `-1`
3. 往左或往右找到 `target` - 回傳 `distance`

```csharp
// 如果起始位置本身就是 target 就直接回傳 0
if (words[startIndex] == target) return 0;

var wordsLength = words.Length;

// 預設距離是 0
var distance = 0;

// 最大距離是陣列的一半
// 距離超過一半時代表找完了
while (distance <= wordsLength / 2)
{
    distance++;
    
    // 往左找有可能索引為負，要加上長度平衡回來
    var leftIndex = startIndex - distance;
    if (leftIndex < 0) leftIndex += wordsLength;
    
    // 往右找有可能索引超出陣列長度，要剪掉長度平衡回來
    var rightIndex = startIndex + distance;
    if (rightIndex >= words.Length) rightIndex -= words.Length;
    
    // 如果找到 target 就直接回傳現在的距離
    if (words[leftIndex] == target || words[rightIndex] == target)
    {
        return distance;
    }
}

// 如果沒找到 target 就回傳 -1
return -1;
```

## 效能
- Time Complexity: O(N)
- Space Complexity: O(1)
- Runtime: 89 ms
- Memory Usage: 47 MB