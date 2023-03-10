using System.Collections;

namespace LeetCode.Test;

[TestFixture]
public class ValidParenthesesTests
{
    private ValidParentheses _validParentheses;

    [SetUp]
    public void Setup()
    {
        _validParentheses = new ValidParentheses();
    }

    [TestCaseSource(nameof(IsNotValidTestCasesData))]
    public void is_not_valid_when_do_third_time(string s)
    {
        var isValid = _validParentheses.DoThirdTime(s);
        
        Assert.IsFalse(isValid);
    }

    [TestCaseSource(nameof(IsValidTestCasesData))]
    public void is_valid_when_do_third_time(string s)
    {
        var isValid = _validParentheses.DoThirdTime(s);
        
        Assert.IsTrue(isValid);
    }

    [TestCaseSource(nameof(IsNotValidTestCasesData))]
    public void is_not_valid_when_do_second_time(string s)
    {
        var isValid = _validParentheses.DoSecondTime(s);
        
        Assert.IsFalse(isValid);
    }

    [TestCaseSource(nameof(IsValidTestCasesData))]
    public void is_valid_when_do_second_time(string s)
    {
        var isValid = _validParentheses.DoSecondTime(s);
        
        Assert.IsTrue(isValid);
    }

    [TestCaseSource(nameof(IsNotValidTestCasesData))]
    public void is_not_valid(string s)
    {
        var isValid = _validParentheses.DoFirstTime(s);
        
        Assert.IsFalse(isValid);
    }
    
    [TestCaseSource(nameof(IsValidTestCasesData))]
    public void is_valid(string s)
    {
        var isValid = _validParentheses.DoFirstTime(s);
        
        Assert.IsTrue(isValid);
    }

    public static IEnumerable IsNotValidTestCasesData
    {
        get
        {
            yield return new TestCaseData("(]");
            yield return new TestCaseData("(){}}{");
            yield return new TestCaseData("]");
            yield return new TestCaseData("({{{{}}}))");
            yield return new TestCaseData("(}{)");
            yield return new TestCaseData("[([]])");
            yield return new TestCaseData("([}}])");
            yield return new TestCaseData("[({])}");
            yield return new TestCaseData("((");
        }
    }

    public static IEnumerable IsValidTestCasesData
    {
        get
        {
            yield return new TestCaseData("()");
            yield return new TestCaseData("{[]}");
            yield return new TestCaseData("()[]{}");
            yield return new TestCaseData("(([]){})");
            yield return new TestCaseData("[({(())}[()])]");
        }
    }
}