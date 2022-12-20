namespace LeetCode;

public class ValidParentheses
{
    public bool DoFirstTime(string s)
    {
        var length = s.Length;
        
        var isOdd = length % 2 == 0;
        if (!isOdd) return false;
        
        var secondParentheses = new Dictionary<string, string>()
        {
            {")", "("},
            {"]", "["},
            {"}", "{"},
        };

        var used = new Dictionary<int, int>();
        for (var index = 1; index < length; index++)
        {
            var currentString = s.Substring(index, 1);
            var isSecondParenthesis = secondParentheses.TryGetValue(currentString, out var firstParenthesis);
            if (isSecondParenthesis)
            {
                for (var previousIndex = index - 1; previousIndex >= 0; previousIndex--)
                {
                    var isPreviousStringUsed = used.TryGetValue(previousIndex, out _);
                    if (isPreviousStringUsed) continue;
                    
                    var previousString = s.Substring(previousIndex, 1);
                    if (previousString == firstParenthesis)
                    {
                        if (used.Count > 0)
                        {
                            var isOverload = used.Any(x =>
                                x.Key < previousIndex && previousIndex < x.Value && x.Value < index);
                            if (isOverload) break;
                        }
                        
                        used[previousIndex] = index;
                        break;
                    }
                }
            }
        }
        
        return used.Count == length / 2;
    }

    public bool DoSecondTime(string s)
    {
        var length = s.Length;
        
        var isOdd = length % 2 == 0;
        if (!isOdd) return false;
        
        var secondParentheses = new Dictionary<string, string>()
        {
            {")", "("},
            {"]", "["},
            {"}", "{"},
        };

        var used = new Dictionary<int, int>();
        var list = s.Select(c => c.ToString()).ToList();

        for (var index = 1; index < length; index++)
        {
            var currentString = s.Substring(index, 1);
            var isSecondParenthesis = secondParentheses.TryGetValue(currentString, out var firstParenthesis);

            if (isSecondParenthesis)
            {
                var indexes = Enumerable.Range(0, list.Count)
                    .Where(i => list[i] == firstParenthesis && i < index)
                    .ToList();
                var except = indexes.Except(used.Keys).ToList();
                if (except.Count == 0) return false;

                var previousIndex = except.Max();
                var isOverload = used.Any(x =>
                    x.Key < previousIndex && previousIndex < x.Value && x.Value < index);
                if (isOverload) return false;

                used[previousIndex] = index;
            }
        }

        return used.Count == length / 2;
    }

    public bool DoThirdTime(string s)
    {
        if (s.Length % 2 != 0) return false;
        
        var openParentheses = new Dictionary<char, char>()
        {
            {'(', ')'},
            {'[', ']'},
            {'{', '}'},
        };

        var usedClosedParentheses = new Stack<char>();
        foreach (var c in s)
        {
            if (openParentheses.ContainsKey(c))
            {
                usedClosedParentheses.Push(openParentheses[c]);
            }
            else if (openParentheses.ContainsValue(c))
            {
                if (usedClosedParentheses.Count == 0 || usedClosedParentheses.Pop() != c) return false;
            }
            else
            {
                return false;
            }
        }

        return usedClosedParentheses.Count == 0;
    }
}