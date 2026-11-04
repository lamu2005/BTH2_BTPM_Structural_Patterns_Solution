using System;

namespace BridgePattern
{
    public interface IImplementation
    {
        string OperationImplementation();
    }

    public class ConcreteImplementationA : IImplementation
    {
        public string OperationImplementation() => "ConcreteImplementationA: Result on platform A.";
    }

    public class ConcreteImplementationB : IImplementation
    {
        public string OperationImplementation() => "ConcreteImplementationB: Result on platform B.";
    }

    public class Abstraction
    {
        protected IImplementation _implementation;
        public Abstraction(IImplementation implementation) => _implementation = implementation;

        public virtual string Operation() => "Abstract: Base operation with:\n" + _implementation.OperationImplementation();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BRIDGE PATTERN (LY THUYET) ===");
            Abstraction abstraction1 = new Abstraction(new ConcreteImplementationA());
            Console.WriteLine(abstraction1.Operation());

            Abstraction abstraction2 = new Abstraction(new ConcreteImplementationB());
            Console.WriteLine(abstraction2.Operation());

            Console.ReadLine();
        }
    }
}