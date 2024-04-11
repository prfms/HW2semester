using StackCalc;
using StackCalc.Stack;

Console.WriteLine("Hi, I'm a stack calculator, I can calculate an expression written in reverse Polish notation!");
Console.Write("Enter your expression: ");
var expression = Console.ReadLine();

while (string.IsNullOrEmpty(expression))
{
    Console.Write("Error! The expression can't be empty.\nTry again: ");
    expression = Console.ReadLine();
}

var stackArray = new StackArray();
var stackCalculator = new StackCalculator(stackArray);
var result = 0.0;

result = stackCalculator.CalculateExpression(expression);

Console.WriteLine($"\nResponse received on stack based on ARRAY: {result}");

var stackList = new StackList();
stackCalculator = new StackCalculator(stackList);

result = stackCalculator.CalculateExpression(expression);

Console.WriteLine($"\nResponse received on stack based on LIST: {result}");

