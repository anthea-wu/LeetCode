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
        var isValid = false;
        var counter = 0;
        for (var index = 0; index < s.Length; index ++)
        {
            if (counter == s.Length) break;
            
            var firstString = s.Substring(index, 1);
            var isFirstExisted = firstParentheses.TryGetValue(firstString, out _);
            if (isFirstExisted)
            {
                var secondString = s.Substring(s.Length - index - 1, 1);
                var isSecondExisted = secondParentheses.TryGetValue(secondString, out var expected);
                if (!isSecondExisted || expected != firstString)
                {
                    try
                    {
                        var closedSecondString = s.Substring(index + 1, 1);
                        var isClosedSecondExisted = secondParentheses.TryGetValue(closedSecondString, out var expectedClosed);
                        if (!isClosedSecondExisted || expectedClosed != firstString)
                        {
                            isValid = false;
                        }
                        else
                        {
                            counter++;
                            isValid = true;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        isValid = false;
                    }
                }
                else
                {
                    counter++;
                    isValid = true;
                }
            }
            else
            {
                counter++;
            }
        }
        return isValid;
    }
}