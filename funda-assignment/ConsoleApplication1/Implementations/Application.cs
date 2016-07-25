using System.IO;
using System.Linq;

using ConsoleApplication1.Interfaces;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class Application : IApplication
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(Application));

        private readonly IMakelaarDomainModelIListConverter makelaarDomainModelIListConverter;

        public Application(IMakelaarDomainModelIListConverter makelaarDomainModelIListConverter)
        {
            this.makelaarDomainModelIListConverter = makelaarDomainModelIListConverter;
        }

        public void Run(IMakelaarRepository repository, TextWriter writer)
        {
            var message = $"{nameof(Application)} gestart";
            this.logger.Info(message: message);

            var top10 = repository.Take(10).ToList();
            var viewdata = this.makelaarDomainModelIListConverter.ToMakelaarPartialViewModels(top10);

            writer.WriteLine(message);
            viewdata.ToList().ForEach(makelaar => writer.WriteLine($"{makelaar.Positie}, {makelaar.Naam}, {makelaar.TotaalAantalObjecten}"));
            writer.WriteLine();

            this.logger.Info(nameof(Application) + " gestopt.");
        }
    }
}