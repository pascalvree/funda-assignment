using System;

using ConsoleApplication1.Interfaces;

namespace ConsoleApplication1.Implementations
{
    // will be automatically wired up by default convention
    public class Writer : IWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}