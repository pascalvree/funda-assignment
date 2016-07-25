using System;
using System.IO;

using ConsoleApplication1.DependencyResolution;
using ConsoleApplication1.Interfaces;

using log4net;

using StructureMap;

using IFundaObjectDtoConverter = ConsoleApplication1.Interfaces.IFundaObjectDtoConverter;

namespace ConsoleApplication1
{
    public class ConsoleApplication1
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ConsoleApplication1));

        private static readonly IContainer Container = StructureMap.Container.For<DefaultRegistry>();
        private static readonly IApplication Application = Container.GetInstance<IApplication>();
        private static readonly IMakelaarRepository MakelaarRepository = Container.GetInstance<IMakelaarRepository>();
        private static readonly IFundaAanbodRepository FundaAanbodRepository = Container.GetInstance<IFundaAanbodRepository>();
        private static readonly IFundaObjectDtoConverter FundaObjectDtoConverter = Container.GetInstance<IFundaObjectDtoConverter>();

        public static void StartApplication(string link, TextWriter writer)
        {
            Logger.Info($"Gestart met ophalen van content @{link}");

            var amsterdamseKoopAanbod = FundaAanbodRepository.GetAll(link);
            Logger.Info($"@{amsterdamseKoopAanbod.Count} objecten ingeladen");

            var makelaars = FundaObjectDtoConverter.ToMakelaarDomainModels(amsterdamseKoopAanbod);
            Logger.Info($"@{makelaars.Count} makelaars gevonden");

            MakelaarRepository.Clear();
            MakelaarRepository.Add(makelaars);
            Application.Run(MakelaarRepository, writer);
        }

        public static void Main(string[] args)
        {
            const string FundaAanbodInAmsterdamLink = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/005e7c1d6f6c4f9bacac16760286e3cd/?type=koop&zo=/amsterdam";
            StartApplication(FundaAanbodInAmsterdamLink, Console.Out);

            const string FundaAanbodInAmsterdamMetTuinLink = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/005e7c1d6f6c4f9bacac16760286e3cd/?type=koop&zo=/amsterdam/tuin/";
            StartApplication(FundaAanbodInAmsterdamMetTuinLink, Console.Out);

            Console.ReadKey();
        }
    }
}