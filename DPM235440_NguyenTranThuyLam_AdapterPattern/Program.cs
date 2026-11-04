using System;

namespace AdapterPattern
{
    public interface ITarget
    {
        string GetRequest();
    }

    public class Adaptee
    {
        public string GetSpecificRequest() => "Specific request.";
    }

    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;
        public Adapter(Adaptee adaptee) => _adaptee = adaptee;

        public string GetRequest() => $"This is '{_adaptee.GetSpecificRequest()}'";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ADAPTER PATTERN (LY THUYET) ===");
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine(target.GetRequest());
            Console.ReadLine();
        }
    }
}