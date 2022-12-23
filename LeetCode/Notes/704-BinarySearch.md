# 704. Binary Search
> Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.  
> 
> You must write an algorithm with O(log n) runtime complexity.  
> 
> ---
> Example 1:
> ```
> Input: nums = [-1,0,3,5,9,12], target = 9
> Output: 4
> Explanation: 9 exists in nums and its index is 4
> ```
> Example 2:
> ```
> Input: nums = [-1,0,3,5,9,12], target = 2
> Output: -1
> Explanation: 2 does not exist in nums so return -1
> ```
>
> ---
> Constraints:
> 1. `1 <= nums.length <= 10^4` 
> 2. `-10^4 < nums[i], target < 10^4` 
> 3. All the integers in nums are unique. 
> 4. nums is sorted in ascending order.

## 最佳解：二分法
看到題目沒有感覺系列，參考[代碼隨想錄](https://github.com/youngyangyang04/leetcode-master/blob/master/problems/0704.%E4%BA%8C%E5%88%86%E6%9F%A5%E6%89%BE.md)練習。

## 相關題目

- [x] [35. Search Insert Position](https://leetcode.com/problems/search-insert-position/)
- [ ] [34. Find First and Last Position of Element in Sorted Array](https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/)
- [ ] [69. Sqrt(x)](https://leetcode.com/problems/sqrtx/)
- [ ] [367. Valid Perfect Square](https://leetcode.com/problems/valid-perfect-square/)
