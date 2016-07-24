using System;
using System.Linq;
using ConsoleApplication1.Models;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class Application
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(Application));

        public void Run()
        {
            //json, makelaars in amsterdam, listed for sale without garden(no paging): http://partnerapi.funda.nl/feeds/Aanbod.svc/json/005e7c1d6f6c4f9bacac16760286e3cd/?type=koop&zo=/amsterdam/&page=1&pagesize=5000
            // makelaar, number of objects
            this.logger.Info(nameof(Application) + " started.");

            var makelaars = Enumerable.Range(1, 255).Select(makelaarId => new MakelaarDto() { Naam = $"Makelaar {makelaarId}", Id = $"m{makelaarId}", TotaalAantalObjecten = makelaarId / 5 }).OrderByDescending(makelaar => makelaar.TotaalAantalObjecten);
            var makelaarRepository = new MakelaarRepository(makelaars);
            makelaarRepository.Top10().ToList().ForEach(makelaar => Console.WriteLine($"{makelaar.Naam}: {makelaar.TotaalAantalObjecten}"));

            var makelaarsZonderTuin = Enumerable.Range(256, 511).Select(makelaarId => new MakelaarDto() { Naam = $"Makelaar {makelaarId}", Id = $"m{makelaarId}", TotaalAantalObjecten = makelaarId / 5 }).OrderByDescending(makelaar => makelaar.TotaalAantalObjecten);
            var makelaarRepositoryZonderTuin = new MakelaarRepository(makelaarsZonderTuin);
            makelaarRepositoryZonderTuin.Top10().ToList().ForEach(makelaar => Console.WriteLine($"{makelaar.Naam}: {makelaar.TotaalAantalObjecten}"));

            this.logger.Info(nameof(Application) + " finished.");
        }
    }

}