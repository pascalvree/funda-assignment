using ConsoleApplication1.Models;

namespace ConsoleApplication1.Interfaces
{
    public interface IMakelaarDomainModelConverter
    {
        MakelaarPartialViewModel ToMakelaarPartialViewModel(MakelaarDomainModel domainModel, int positie);
    }
}