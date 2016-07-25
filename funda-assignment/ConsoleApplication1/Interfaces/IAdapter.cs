using System.IO;

namespace ConsoleApplication1.Interfaces
{
    public interface IAdapter<out T> where T : class
    {
        T Adapt(Stream stream);
    }
}