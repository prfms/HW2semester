using ParseTree.Utils;

namespace ParseTree;

/// <summary>
/// Data structure for storing, representing,
/// and evaluating an expression in prefix notation.
/// </summary>
public class Tree
{
    private readonly IParsingTreeElement _top;

    /// <summary>
    /// Constructor that converts the prefix expression and populates the tree.
    /// </summary>
    /// <exception cref="ExpressionException"> Expression has invalid format. </exception>
    /// <exception cref="DivideByZeroException"> Expression contains division by zero. </exception>
    public Tree(string expression)
    {
        if (expression == string.Empty)
        {
            throw new ExpressionException("Expression can`t be empty");
        }

        var expressionParts = expression.Replace(")", "").Replace("(", "").Split(" ");
        var pointer = 0;

        _top = GetTreeElement(expressionParts[pointer++]);
        BuildTree(_top, expressionParts, ref pointer);

        if (_top is NumberElement && expressionParts.Length > 1)
        {
            throw new ExpressionException("If the first expression element is number," +
                                           " then expression must contain one element.");
        }
    }

    private static IParsingTreeElement GetTreeElement(string value)
    {
        if (int.TryParse(value, out var number))
        {
            return new NumberElement(number);
        }
        return new OperationElement(value);
    }

    private void BuildTree(IParsingTreeElement currentVertex, string[] expressionParts, ref int pointer)
    {
        if (currentVertex is NumberElement)
        {
            return;
        }

        var firstOperand = GetTreeElement(expressionParts[pointer++]);
        FillOperand((OperationElement)currentVertex, firstOperand, 1, expressionParts, ref pointer);

        var secondOperand = GetTreeElement(expressionParts[pointer++]);
        FillOperand((OperationElement)currentVertex, secondOperand, 2, expressionParts, ref pointer);
    }

    private void FillOperand(OperationElement operation, IParsingTreeElement operand, int operandNumber, string[] expressionParts, ref int pointer)
    {
        if (pointer > expressionParts.Length)
        {
            throw new ExpressionException("This is not a prefix expression");
        }

        if (operand is OperationElement)
        {
            BuildTree(operand, expressionParts, ref pointer);
        }

        if (operandNumber == 1)
        {
            operation.FirstOperand = operand;
        }
        else
        {
            operation.SecondOperand = operand;
        }
    }

    public override string ToString() => _top.ToString();

    public double Calculate() => _top.Calculate();
}