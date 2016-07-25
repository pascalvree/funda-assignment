using System.Collections.Generic;
using System.IO;
using System.Linq;

using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class Application : IApplication
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(Application));

        private readonly IMakelaarRepository repository;
        private readonly IMakelaarDomainModelIListConverter makelaarDomainModelIListConverter;

        public Application(IMakelaarDomainModelIListConverter makelaarDomainModelIListConverter, IMakelaarRepository repository)
        {
            this.repository = repository;
            this.makelaarDomainModelIListConverter = makelaarDomainModelIListConverter;
        }

        public void Run(IList<MakelaarDomainModel> makelaars, TextWriter writer)
        {
            var message = $"{nameof(Application)} gestart met {makelaars.Count()} makelaars";
            this.logger.Info(message: message);

            this.repository.Clear();
            this.repository.Add(makelaars);

            var top10 = this.repository.Take(10).ToList();
            var viewdata = this.makelaarDomainModelIListConverter.ToMakelaarPartialViewModels(top10);

            writer.WriteLine(message);
            viewdata.ToList().ForEach(makelaar => writer.WriteLine($"{makelaar.Positie}, {makelaar.Naam}, {makelaar.TotaalAantalObjecten}"));
            writer.WriteLine();

            this.logger.Info(nameof(Application) + " gestopt.");
        }
    }
}