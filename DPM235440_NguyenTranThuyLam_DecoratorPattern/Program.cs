using System;

namespace DecoratorPattern
{
    public abstract class Component
    {
        public abstract string Operation();
    }

    public class ConcreteComponent : Component
    {
        public override string Operation() => "ConcreteComponent";
    }

    public abstract class Decorator : Component
    {
        protected Component _component;
        public Decorator(Component component) => _component = component;

        public override string Operation() => _component != null ? _component.Operation() : string.Empty;
    }

    public class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component comp) : base(comp) { }
        public override string Operation() => $"ConcreteDecoratorA({base.Operation()})";
    }

    public class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component comp) : base(comp) { }
        public override string Operation() => $"ConcreteDecoratorB({base.Operation()})";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DECORATOR PATTERN (LY THUYET) ===");
            ConcreteComponent simple = new ConcreteComponent();
            ConcreteDecoratorA decoratorA = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decoratorB = new ConcreteDecoratorB(decoratorA);

            Console.WriteLine(decoratorB.Operation());
            Console.ReadLine();
        }
    }
}