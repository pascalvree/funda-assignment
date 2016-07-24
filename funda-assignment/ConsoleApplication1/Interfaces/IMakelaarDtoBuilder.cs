using ConsoleApplication1.Models;

namespace ConsoleApplication1.Interfaces
{

    public interface IMakelaarDtoBuilder
    {
        MakelaarDto Create(string id, string naam, int totaalAantalObjecten);
    }
}