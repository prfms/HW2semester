namespace StackCalc.Stack;

/// <summary>
/// Stack realization by using array.
/// </summary>
public class StackArray : IStack
{
    
    private readonly List<double> _stack = new();

    /// <inheritdoc/>
    public void Push(double value)
    {
        _stack.Add(value);
    }

    /// <inheritdoc/>
    public double Pop()
    {
        
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't to Pop() from empty _stack.");
        }
        
        var upElement = _stack[^1];
        _stack.RemoveAt(_stack.Count - 1);
        return upElement;
    }

    /// <inheritdoc/>
    public bool IsEmpty()
    {
        return _stack.Count == 0;
    }
}

