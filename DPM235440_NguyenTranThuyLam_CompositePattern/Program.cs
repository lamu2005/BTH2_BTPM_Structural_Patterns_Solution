using System;
using System.Collections.Generic;

namespace CompositePattern
{
    public abstract class Component
    {
        public abstract string Operation();
        public virtual void Add(Component component) { throw new NotImplementedException(); }
        public virtual void Remove(Component component) { throw new NotImplementedException(); }
    }

    public class Leaf : Component
    {
        public override string Operation() => "Leaf";
    }

    public class Composite : Component
    {
        protected List<Component> _children = new List<Component>();

        public override void Add(Component component) => _children.Add(component);
        public override void Remove(Component component) => _children.Remove(component);

        public override string Operation()
        {
            List<string> results = new List<string>();
            foreach (Component component in _children)
            {
                results.Add(component.Operation());
            }
            return $"Branch({string.Join("+", results)})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== COMPOSITE PATTERN (LY THUYET) ===");
            Composite tree = new Composite();
            Composite branch = new Composite();
            branch.Add(new Leaf());
            branch.Add(new Leaf());

            tree.Add(branch);
            tree.Add(new Leaf());

            Console.WriteLine(tree.Operation());
            Console.ReadLine();
        }
    }
}