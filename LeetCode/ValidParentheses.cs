namespace LeetCode;

public class ValidParentheses
{
    public bool DoFirstTime(string s)
    {
        var firstParentheses = new Dictionary<string, string>()
        {
            {"(", ")"},
            {"[", "]"},
            {"{", "}"},
        };
        var secondParentheses = new Dictionary<string, string>()
        {
            {")", "("},
            {"]", "["},
            {"}", "{"},
        };
        for (var index = 0; index < s.Length / 2; index += 2)
        {
            var firstString = s.Substring(index, 1);
            var isFirstExisted = firstParentheses.TryGetValue(firstString, out _);
            if (isFirstExisted)
            {
                var secondString = s.Substring(index + 1, 1);
                var isSecondExisted = secondParentheses.TryGetValue(secondString, out var expected);
                return isSecondExisted && expected == firstString;
            }
        }
        return false;
    }
}