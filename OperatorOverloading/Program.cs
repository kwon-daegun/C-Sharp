using OperatorOverloading;

// We use 'new()' because C# already knows we are making Rectangles (Target-typed new).
Rectangle rect1 = new(12, 10);
Rectangle rect2 = new(5, 2);

// The compiler sees '+' between two Rectangles and calls your static method
Rectangle result = rect1 + rect2;

Console.WriteLine($"First:  {rect1}");
Console.WriteLine($"Second: {rect2}");
Console.WriteLine($"Result: {result}");

namespace OperatorOverloading
{

    // 1. record struct: Lightweight, fast, and gives us a free ToString()!
    // 2. Primary Constructor: We define Width and Height right in the declaration.
    public record struct Rectangle(int Width, int Height)
    {
        // 3. Operator Overloading
        // We use '=>' (lambda arrow) to make this a one-line method.
        public static Rectangle operator +(Rectangle left, Rectangle right)
            => new Rectangle(left.Width + right.Width, left.Height + right.Height);
    }
}
