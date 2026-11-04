using System;
using System.Collections.Generic;

namespace FlyweightPattern
{
    public class Flyweight
    {
        private string _sharedState;
        public Flyweight(string sharedState) => _sharedState = sharedState;

        public void Operation(string uniqueState)
        {
            Console.WriteLine($"Flyweight: Shared ({_sharedState}) and Unique ({uniqueState}) state.");
        }
    }

    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> _flyweights = new Dictionary<string, Flyweight>();

        public Flyweight GetFlyweight(string key)
        {
            if (!_flyweights.ContainsKey(key))
            {
                _flyweights[key] = new Flyweight(key);
            }
            return _flyweights[key];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== FLYWEIGHT PATTERN (LY THUYET) ===");
            FlyweightFactory factory = new FlyweightFactory();

            Flyweight f1 = factory.GetFlyweight("StateA");
            f1.Operation("Unique1");

            Flyweight f2 = factory.GetFlyweight("StateA");
            f2.Operation("Unique2");

            Console.ReadLine();
        }
    }
}