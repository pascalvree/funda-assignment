
using StructureMap;
using StructureMap.Graph;

namespace ConsoleApplication1.DependencyResolution
{
    public class ConsoleRegistry : Registry
    {
        public ConsoleRegistry()
        {
            this.Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}