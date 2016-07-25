using ConsoleApplication1.Models;

namespace ConsoleApplication1.Interfaces
{
    public interface IMakelaarDomainModelBuilder
    {
        MakelaarDomainModel Create(string id, string naam, int totaalAantalObjecten);
    }
}