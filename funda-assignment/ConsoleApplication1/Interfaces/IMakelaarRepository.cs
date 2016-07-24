using System.Collections.Generic;

using ConsoleApplication1.Implementations;
using ConsoleApplication1.Models;

namespace ConsoleApplication1.Interfaces
{
    public interface IMakelaarRepository
    {
        IEnumerable<MakelaarDto> Top10();
    }
}