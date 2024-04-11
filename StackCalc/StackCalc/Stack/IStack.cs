namespace StackCalc.Stack;

/// <summary>
/// Stack, a last in — first out container for real values.
/// </summary>
public interface IStack
{
    /// <summary>
    /// Add element in stack.
    /// </summary>
    /// <param name="value"> Value to add.</param>
    public void Push(double value);

    /// <summary>
    /// Returns and removes an element from the top of the stack.
    /// </summary>
    /// <returns> Top element of the stack. </returns>
    /// <exception cref="InvalidOperationException"> Can't to Pop() from empty stack. </exception>
    public double Pop();

    /// <summary>
    /// Checking for stack empty.
    /// </summary>
    /// <returns> True - the stack is empty, False - the stack is not empty. </returns>
    public bool IsEmpty();
}




public interface IPlusable<T>
{
    public T Plus(IPlusable<T> operand);
}

class Polynom : IPlusable<Polynom>
{
    public Polynom Plus(IPlusable<Polynom> operand)
    {
        throw new NotImplementedException();
    }
}

public static class Math<T> where T: IPlusable<T>
{
    public static void Plus(T operand1, T operand2)
    {
        operand1.Plus(operand2);
    }
}



