using System;
using System.Linq;

using ConsoleApplication1.DependencyResolution;
using ConsoleApplication1.Interfaces;

using StructureMap;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = Container.For<DefaultRegistry>();
            var application = container.GetInstance<IApplication>();
            var fundaAanbodRestClient = container.GetInstance<IFundaAanbodRestClient>();
            var makelaarDomainModelBuilder = container.GetInstance<IMakelaarDomainModelBuilder>();

            var link = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/005e7c1d6f6c4f9bacac16760286e3cd/?type=koop&zo=/amsterdam";
            Console.WriteLine($"Gestart met ophalen van content @{link}");

            var amsterdamseKoopAanbod = fundaAanbodRestClient.GetAll(link);
            var asd = amsterdamseKoopAanbod.Select(fundaObject => new { Id = fundaObject.MakelaarId, Naam = fundaObject.MakelaarNaam }).GroupBy(makelaar => makelaar.Id).Select(makelaar => makelaarDomainModelBuilder.Create(makelaar.Key.ToString(), makelaar.First().Naam, makelaar.Count())).OrderByDescending(makelaar => makelaar.TotaalAantalObjecten).ToList();
            application.Run(asd, Console.Out);

            link = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/005e7c1d6f6c4f9bacac16760286e3cd/?type=koop&zo=/amsterdam/tuin/";
            Console.WriteLine($"Gestart met ophalen van content @{link}");

            var amsterdamseKoopAanbodMetTuin = fundaAanbodRestClient.GetAll(link);
            var zxc = amsterdamseKoopAanbodMetTuin.Select(fundaObject => new { Id = fundaObject.MakelaarId, Naam = fundaObject.MakelaarNaam }).GroupBy(makelaar => makelaar.Id).Select(makelaar => makelaarDomainModelBuilder.Create(makelaar.Key.ToString(), makelaar.First().Naam, makelaar.Count())).OrderByDescending(makelaar => makelaar.TotaalAantalObjecten).ToList();
            application.Run(zxc, Console.Out);
        }
    }
}