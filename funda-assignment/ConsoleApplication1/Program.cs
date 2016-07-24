using ConsoleApplication1.DependencyResolution;
using ConsoleApplication1.Implementations;

using StructureMap;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = Container.For<ConsoleRegistry>();
            var app = container.GetInstance<Application>();
            app.Run();
        }
    }
}