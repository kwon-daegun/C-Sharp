namespace HelloName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your name: "); // prompt user for input

            var name = Console.ReadLine(); // store user input
            Console.WriteLine($"Hello, {name}!"); // string interpolation
        }
    }
}