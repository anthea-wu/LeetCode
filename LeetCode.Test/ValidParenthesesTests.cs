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

    [Test]
    public void is_not_valid()
    {
        var s = "(]";

        var isValid = _validParentheses.DoFirstTime(s);
        
        Assert.IsFalse(isValid);
    }
    
    [Test]
    public void is_valid()
    {
        var s = "()";
        
        var isValid = _validParentheses.DoFirstTime(s);
        
        Assert.IsTrue(isValid);
    }    
}