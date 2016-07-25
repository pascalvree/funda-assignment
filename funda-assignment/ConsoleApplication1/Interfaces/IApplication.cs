using System.IO;

namespace ConsoleApplication1.Interfaces
{
    public interface IApplication
    {
        void Run(IMakelaarRepository repository, TextWriter writer);
    }
}