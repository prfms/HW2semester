using StackCalc.Stack;

namespace StackCalc;

/// <summary>
///  Class for polish postfix expression calculation.
/// </summary>
public class StackCalculator(IStack stack)
{
    private static bool IsZero(double number)
        => Math.Abs(number) < 0.0001;
    

    private void Operations(string sign)
    {
        var firstElement = 0.0;
        var secondElement = 0.0;

        try
        {
            firstElement = stack.Pop();
            secondElement = stack.Pop();
        }
        catch (InvalidOperationException)
        {
            throw new ArgumentException("Incorrect expression.");
        }

        switch (sign)
        {
            case "+":
                stack.Push(firstElement + secondElement);
                break;

            case "-":
                stack.Push(secondElement - firstElement);
                break;

            case "*":
                stack.Push(firstElement * secondElement);
                break;

            case "/":
                if (IsZero(firstElement))
                {
                    throw new DivideByZeroException();
                }

                stack.Push(secondElement / firstElement);
                break;
        }
    }

    /// <summary>
    /// A method for calculating the Polish postfix expression.
    /// </summary>
    /// <param name="expression"> Expression in reverse Polish notation. </param>
    /// <returns> Value of expression. </returns>
    public double CalculateExpression(string? expression)
    {
        switch (expression)
        {
            case null:
                throw new ArgumentNullException(nameof(expression), "can't be null.");
            case "":
                throw new ArgumentException(nameof(expression), "can't be empty.");
        }

        var operations = "+-*/";
        foreach (var element in expression.Split(" ", StringSplitOptions.RemoveEmptyEntries))
        {
            if (operations.Contains(element))
            {
                Operations(element);
            }
            else
            {
                if (!int.TryParse(element, out var number))
                {
                    throw new ArgumentException("Incorrect expression.");
                }
                stack.Push(number);
            }
        }

        var result = 0.0;
        try
        {
            result = stack.Pop();
        }
        catch (InvalidOperationException)
        {
            throw new ArgumentException("Incorrect expression.");
        }

        if (!stack.IsEmpty())
        {
            throw new ArgumentException("Incorrect expression.");
        }

        return result;
    }
}