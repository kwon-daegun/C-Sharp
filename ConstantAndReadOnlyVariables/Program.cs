using System;
using Microsoft.Extensions.Configuration;

namespace ConstantAndReadOnlyVariables
{
    // SOLID Principle - In OOPs
    // S - Single Responsibility Principle
    // O - Open/Closed principle
    // L - Liskov Substitution Principle
    // I - Interface Segration Principle
    // D - Dependency Inversion Principle

    public static class PhysicsConstants
    {
        public const int SpeedOfLight = 300_000;
    }
    public class Mars(int distanceToMarsFromEarth)
    {
        public readonly int DistanceToMars = distanceToMarsFromEarth;

        public double GetInfoTravelTime()
        {
            return (double)DistanceToMars / PhysicsConstants.SpeedOfLight;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string configuration = config["MarsSettings:Distance"];
            int parsedDistance = int.Parse(configuration);

            Mars mars = new Mars(parsedDistance);

            Console.WriteLine($"Distance: {mars.DistanceToMars:N0} km");
            Console.WriteLine($"Info travel time: {mars.GetInfoTravelTime():F2} seconds.");
        }
    }
}
