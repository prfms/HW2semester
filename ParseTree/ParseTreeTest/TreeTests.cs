namespace ParseTreeTest;
public class TreeTests
{
    [TestCase("(/ (* (- 2 5) (/ (+ 10 5) (* 5 1))) 3)", -3.0)]
    [TestCase("(/ (* 10 2) (+ 3 4))", 2.8571)]
    [TestCase("(* 0 0)", 0.0)]
    [TestCase("(- 123 34", 89.0)]
    [TestCase("(+ 1 1)", 2.0)]
    public void CorrectExpressionTest_ShouldReturnExpectedValue(string expression, double expected)
    {
        var tree = new Tree(expression);

        var actual = tree.Calculate();
        Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
    }

    [Test]
    public void CorrectExpressionWithoutBrackets_ShouldReturnExpectedValue()
    {
        const int expected = 1;
        const string expression = "* / 2 4 / 4 2";
        var tree = new Tree(expression);

        var actual = tree.Calculate();

        Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
    }

    [Test]
    public void DivideByZeroInExpression_ShouldThrowException()
    {
        const string expression = "(/ 0 (- (+ 2 2) (* 1 4)))";
        var tree = new Tree(expression);

        Assert.Throws<DivideByZeroException>(() => tree.Calculate());
    }

    [TestCase("(+ 1 )")]
    [TestCase("( - 1 1)")]
    [TestCase("(1 1 +)")]
    public void InvalidInputFormat_ShouldThrowException(string expression)
        => Assert.Throws<ExpressionException>(() =>
        {
            var tree = new Tree(expression);
        });

    [Test]
    public void EmptyExpression_ShouldThrowException()
        => Assert.Throws<ExpressionException>(() =>
        {
            var tree = new Tree(string.Empty);
        });

    [Test]
    public void InvalidOperationInExpression_ShouldThrowException()
        => Assert.Throws<ExpressionException>(() =>
        {
            var tree = new Tree("(+ (- 1 1) (^ 2 2))");
        });
}