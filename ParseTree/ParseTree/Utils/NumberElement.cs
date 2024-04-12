namespace ParseTree.Utils;

/// <summary>
/// Element of parsing tree, only with integer value.
/// </summary>
public class NumberElement(int value) : IParsingTreeElement
{
    private int Value { get; } = value;

    /// <inheritdoc/>
    public double Calculate() => Value;

    /// <inheritdoc/>
    public override string ToString() => Value.ToString();
}