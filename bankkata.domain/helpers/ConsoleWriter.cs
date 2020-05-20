using System;
using bankkata.domain.helpers.contracts;

namespace bankkata.domain.helpers
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}