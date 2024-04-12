namespace ParseTree;

public class ExpressionException: Exception
{
    public ExpressionException(): base() { }
    public ExpressionException(string message): base(message) { }
}