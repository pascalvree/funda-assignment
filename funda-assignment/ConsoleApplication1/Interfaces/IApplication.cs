using System.Collections.Generic;
using System.IO;

using ConsoleApplication1.Models;

namespace ConsoleApplication1.Interfaces
{
    public interface IApplication
    {
        void Run(IList<MakelaarDomainModel> makelaars, TextWriter writer);
    }
}