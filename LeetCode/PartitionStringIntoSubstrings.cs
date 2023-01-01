namespace LeetCode;

public class PartitionStringIntoSubstrings
{
    public int Do(string s, int k)
    {
        var result = 0;
        var total = "";

        foreach (var item in s)
        {
            if (item - '0' > k) return -1;

            var current = item.ToString();
            total += current;
            var sum = Convert.ToDouble(total);

            if (sum > k)
            {
                result++;
                total = current;
            }
        }

        return result + 1;
    }
}