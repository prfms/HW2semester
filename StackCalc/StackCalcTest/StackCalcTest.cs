namespace StackCalcTest;

using StackCalc;
using StackCalc.Stack;

public class StackCalculatorTests
{
    private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
    {
        new TestCaseData(new StackCalculator(new StackArray())),
        new TestCaseData(new StackCalculator(new StackList())),
    };

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_CorrectExpression_CorrectAnswerReturned(StackCalculator stackCalculator)
    {
        const string expression = "10 20 + 3 *";
        const int expected = 90;

        var actual = stackCalculator.CalculateExpression(expression);

        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_CorrectExpression_CorrectFloatAnswerReturned(StackCalculator stackCalculator)
    {
        const string expression = "10 3 /";
        const double expected = 3.3333;

        var actual = stackCalculator.CalculateExpression(expression);

        Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_FractionalNumbers_ExceptionReturned(StackCalculator stackCalculator)
    {
        const string expression = "10.2 20.4 + 5 * 0 -";

        Assert.Throws<ArgumentException>(() => stackCalculator.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_IncorrectExpression1_ExceptionReturned(StackCalculator stackCalculator)
    {
        const string expression = "10 20 + 3 * 2";

        Assert.Throws<ArgumentException>(() => stackCalculator.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_IncorrectExpression2_ExceptionReturned(StackCalculator stackCalculator)
    {
        const string expression = "10 A + 3 *";

        Assert.Throws<ArgumentException>(() => stackCalculator.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_IncorrectExpression3_ExceptionReturned(StackCalculator stackCalculator)
    {
        const string expression = "10 2 + 3 %";

        Assert.Throws<ArgumentException>(() => stackCalculator.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_EmptyExpression_ExceptionReturned(StackCalculator stackCalculator)
    {
        var expression = string.Empty;

        Assert.Throws<ArgumentException>(() => stackCalculator.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_Null_ExceptionReturned(StackCalculator stackCalculator)
    {
        string? expression = null;

        Assert.Throws<ArgumentNullException>(() => stackCalculator.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_DivisionByZero_DivideByZeroExceptionReturned(StackCalculator stackCalculator)
    {
        const string expression = "10 2 + 0 /";

        Assert.Throws<DivideByZeroException>(() => stackCalculator.CalculateExpression(expression));
    }
}