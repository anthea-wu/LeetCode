namespace LeetCode;

public class ValidParentheses
{
    public bool DoFirstTime(string s)
    {
        if (s.Length % 2 != 0) return false;
        
        var firstParentheses = new Dictionary<string, string>()
        {
            {"(", ")"},
            {"[", "]"},
            {"{", "}"},
        };

        var used = new Dictionary<int, int>();
        var groupCount = s.Length / 2;
        for (var index = 0; index < s.Length; index ++)
        {
            // 2n+1 / 全沒有就 false
            var firstString = s.Substring(index, 1);
            var isFirstExisted = firstParentheses.TryGetValue(firstString, out _);
            if (isFirstExisted)
            {
                var isAllSecondExisted = false;
                // groupCount + 1 要剪掉 index
                var count = groupCount - index < 0 ? 1 : groupCount - index;
                for (var i = 0; i < count; i++)
                {
                    var secondIndex = 2 * i + 1 + index;
                    if (used.TryGetValue(secondIndex, out _)) continue;

                    try
                    {
                        var secondString = s.Substring(secondIndex, 1);
                        var isSecondEqual = firstParentheses[firstString] == secondString;
                        if (isSecondEqual)
                        {
                            isAllSecondExisted = true;
                            used[secondIndex] = index;
                            break;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        break;
                    }
                }

                if (!isAllSecondExisted) return false;
            }
            else
            {
                var isUsed = used.TryGetValue(index, out _);
                if (!isUsed) return false;
            }
        }
        return true;
    }
}