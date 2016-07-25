using ConsoleApplication1.Models;

namespace ConsoleApplication1.Interfaces
{
    public interface IMakelaarPartialViewModelBuilder
    {
        MakelaarPartialViewModel Create(int positie, string naam, int totaalAantalObjecten);
    }
}