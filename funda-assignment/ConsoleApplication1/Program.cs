using System;

using ConsoleApplication1.DependencyResolution;
using ConsoleApplication1.Implementations;
using ConsoleApplication1.Interfaces;

using StructureMap;

using IFundaObjectDtoConverter = ConsoleApplication1.Interfaces.IFundaObjectDtoConverter;

namespace ConsoleApplication1
{
    public class ConsoleApplication1
    {
        public static void Main(string[] args)
        {
            var container = Container.For<DefaultRegistry>();
            var application = container.GetInstance<IApplication>();
            var fundaAanbodRestClient = container.GetInstance<IFundaAanbodRepository>();
            var fundaObjectDtoConverter = container.GetInstance<IFundaObjectDtoConverter>();

            var link = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/005e7c1d6f6c4f9bacac16760286e3cd/?type=koop&zo=/amsterdam";
            Console.WriteLine($"Gestart met ophalen van content @{link}");

            var amsterdamseKoopAanbod = fundaAanbodRestClient.GetAll(link);
            application.Run(fundaObjectDtoConverter.ToMakelaarDomainModels(amsterdamseKoopAanbod), Console.Out);

            link = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/005e7c1d6f6c4f9bacac16760286e3cd/?type=koop&zo=/amsterdam/tuin/";
            Console.WriteLine($"Gestart met ophalen van content @{link}");

            var amsterdamseKoopAanbodMetTuin = fundaAanbodRestClient.GetAll(link);
            application.Run(fundaObjectDtoConverter.ToMakelaarDomainModels(amsterdamseKoopAanbodMetTuin), Console.Out);

            Console.ReadKey();
        }
    }
}