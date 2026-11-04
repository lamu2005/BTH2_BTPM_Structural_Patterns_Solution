using System;

namespace ProxyPattern
{
    public interface ISubject
    {
        void Request();
    }

    public class RealSubject : ISubject
    {
        public void Request() => Console.WriteLine("RealSubject: Handling Request.");
    }

    public class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public void Request()
        {
            if (CheckAccess())
            {
                if (_realSubject == null) _realSubject = new RealSubject();
                _realSubject.Request();
                LogAccess();
            }
        }

        private bool CheckAccess()
        {
            Console.WriteLine("Proxy: Checking access prior to issuing a real request.");
            return true;
        }

        private void LogAccess() => Console.WriteLine("Proxy: Logging the time of request.");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PROXY PATTERN (LY THUYET) ===");
            ISubject proxy = new Proxy();
            proxy.Request();
            Console.ReadLine();
        }
    }
}