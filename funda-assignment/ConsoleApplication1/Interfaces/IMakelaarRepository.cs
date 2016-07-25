using System.Collections.Generic;
using ConsoleApplication1.Models;

namespace ConsoleApplication1.Interfaces
{
    public interface IMakelaarRepository
    {
        void Add(IEnumerable<MakelaarDomainModel> makelaars);

        IEnumerable<MakelaarDomainModel> Take(int aantal);

        void Clear();
    }
}