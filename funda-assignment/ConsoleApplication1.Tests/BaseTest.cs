using ConsoleApplication1.DependencyResolution;

using StructureMap;

namespace ConsoleApplication1.Tests
{
    public abstract class BaseTest
    {
        protected readonly Container DiContainer = new Container(c => c.AddRegistry<DefaultRegistry>());
    }
}