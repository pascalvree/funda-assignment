using System.Collections.Generic;

using ConsoleApplication1.Models;

namespace ConsoleApplication1.Interfaces
{
    public interface IMakelaarDomainModelIListConverter
    {
        IEnumerable<MakelaarPartialViewModel> ToMakelaarPartialViewModels(IList<MakelaarDomainModel> domainModels);
    }
}