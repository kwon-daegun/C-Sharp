using System;

namespace DataTypeConversion
{
    // 1. 'readonly' makes the struct faster and safer (immutable).
    // 2. Primary Constructor: We declare 'Feet' right in the class definition.
    public readonly struct ImperialMeasurement(float feet)
    {
        // 3. Define the conversion factor as a constant.
        private const float MetersToFeetRatio = 3.28084f;

        // Property to access the data (Capitalized standard naming convention)
        public float Feet { get; } = feet;

        // MODERN IMPLICIT OPERATOR
        // We use an expression-bodied member (=>) for cleaner syntax.
        // Change the keyword implicit to explicit if user wants user defined explicit data conversion
        public static implicit operator ImperialMeasurement(int meters)
            => new ImperialMeasurement(meters * MetersToFeetRatio);

        // EXTRA: A helper so the object knows how to display itself
        public override string ToString() => $"{Feet:F2} feet";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a whole number measurement in meters:");

            string input = Console.ReadLine();

            // 4. Validate input. If the user types "hello", this handles it gracefully.
            if (int.TryParse(input, out int meters))
            {
                // The implicit conversion happens here automatically
                ImperialMeasurement imperial = meters;

                Console.WriteLine($"The measurement of {meters} meters is {imperial}");

                // Example of Explicit (if you wanted to force it):
                // ImperialMeasurement explicitExample = (ImperialMeasurement)meters;
            }
            else
            {
                Console.WriteLine("That was not a valid number.");
            }

        }
    }
}