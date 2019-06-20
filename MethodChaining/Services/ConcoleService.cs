using MethodChaining.Interfaces;
using System;

namespace MethodChaining.Services
{
    public class ConcoleService : IConsoleService
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
