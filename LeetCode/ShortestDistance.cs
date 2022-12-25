namespace LeetCode;

public class ShortestDistance
{
    public int Do(string[] words, string target, int startIndex)
    {
        if (words[startIndex] == target) return 0;
        
        var temp = 301;
        var wordsLength = words.Length;
        
        var counter = 0;
        var beforeCounter = 0;
        var doubleWords = new string[wordsLength * 2 - 1];
        for (var j = 0; j < 3; j++)
        {
            for (var i = 0; i < wordsLength; i++)
            {
                if (j == 0 && i > startIndex)
                {
                    doubleWords[counter] = words[i];
                    beforeCounter++;
                    counter++;
                }
                else if (j == 2 && i < startIndex)
                {
                    doubleWords[counter] = words[i];
                    counter++;
                }
                else if (j == 1)
                {
                    doubleWords[counter] = words[i];
                    counter++;
                }
            }
        }

        var startIndexInTripleWords = beforeCounter + startIndex;
        for (var i = 0; i < doubleWords.Length; i++)
        {
            if (doubleWords[i] == doubleWords[startIndexInTripleWords]) continue;
            if (doubleWords[i] == target)
            {
                if (temp == -1) temp = i;

                var indexDistance = Math.Abs(i - startIndexInTripleWords);
                if (indexDistance < temp) temp = indexDistance;
            }
        }
        
        for (var i = doubleWords.Length - 1; i >= 0; i--)
        {
            if (doubleWords[i] == doubleWords[startIndexInTripleWords]) continue;
            if (doubleWords[i] == target)
            {
                if (temp == -1) temp = i;

                var indexDistance = Math.Abs(doubleWords.Length - i);
                if (indexDistance < temp) temp = indexDistance;
            }
        }

        return temp > wordsLength ? -1 : temp;
    }

    public int DoSecondTime(string[] words, string target, int startIndex)
    {
        if (words[startIndex] == target) return 0;
        
        var wordsLength = words.Length;
        var distance = 0;
        
        while(distance <= wordsLength / 2)
        {
            distance++;
            
            var leftIndex = startIndex - distance;
            if (leftIndex < 0) leftIndex += wordsLength;
            
            var rightIndex = startIndex + distance;
            if (rightIndex >= words.Length) rightIndex -= words.Length;
            
            if (words[leftIndex] == target || words[rightIndex] == target)
            {
                return distance;
            }
        }

        return -1;
    }
}