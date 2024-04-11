namespace StackCalc.Stack;

/// <summary>
/// Stack realization by using linked list.
/// </summary>
public class StackList : IStack
{
    private readonly LinkedList<double> _stack = new();

    /// <inheritdoc/>
    public void Push(double value)
    {
        _stack.AddFirst(value);
    }

    /// <inheritdoc/>
    public double Pop()
    {
       
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't to Pop() from empty _stack.");
        }

        var result = _stack.First();
        _stack.RemoveFirst();

        return result;
    }

    /// <inheritdoc/>
    public bool IsEmpty()
    {
        return _stack.First == null;
    }
}