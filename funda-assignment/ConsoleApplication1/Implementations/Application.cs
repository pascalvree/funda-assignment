using System;
using System.Linq;

using ConsoleApplication1.Interfaces;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class Application
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(Application));

        private readonly IMakelaarRepository repository;
        private readonly IMakelaarDomainModelBuilder makelaarDomainModelBuilder;
        private readonly IMakelaarDomainModelIListConverter makelaarDomainModelIListConverter;

        public Application(IMakelaarDomainModelBuilder makelaarDomainModelBuilder, IMakelaarDomainModelIListConverter makelaarDomainModelIListConverter, IMakelaarRepository repository)
        {
            this.repository = repository;
            this.makelaarDomainModelBuilder = makelaarDomainModelBuilder;
            this.makelaarDomainModelIListConverter = makelaarDomainModelIListConverter;
        }

        public void Run()
        {
            //json, makelaars in amsterdam, listed for sale without garden(no paging): http://partnerapi.funda.nl/feeds/Aanbod.svc/json/005e7c1d6f6c4f9bacac16760286e3cd/?type=koop&zo=/amsterdam/&page=1&pagesize=5000
            // makelaar, number of objects
            this.logger.Info(nameof(Application) + " started.");

            var makelaars = Enumerable.Range(1, 64).Select(makelaarId => this.makelaarDomainModelBuilder.Create(makelaarId.ToString(), $"m{makelaarId}", makelaarId / 5)).OrderByDescending(makelaar => makelaar.TotaalAantalObjecten).ToList();

            this.repository.Add(makelaars);
            var top10 = this.repository.Top10().ToList();

            var viewdata = this.makelaarDomainModelIListConverter.ToMakelaarPartialViewModels(top10);
            viewdata.ToList().ForEach(makelaar => Console.WriteLine($"{makelaar.Positie}, {makelaar.Naam}, {makelaar.TotaalAantalObjecten}"));

            this.logger.Info(nameof(Application) + " finished.");
        }
    }
}