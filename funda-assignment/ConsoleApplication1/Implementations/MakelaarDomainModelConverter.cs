using System;

using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class MakelaarDomainModelConverter : IMakelaarDomainModelConverter
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(MakelaarDomainModelConverter));
        private readonly IMakelaarPartialViewModelBuilder makelaarPartialViewModelBuilder;

        public MakelaarDomainModelConverter(IMakelaarPartialViewModelBuilder makelaarPartialViewModelBuilder)
        {
            this.makelaarPartialViewModelBuilder = makelaarPartialViewModelBuilder;
        }

        public MakelaarPartialViewModel ToMakelaarPartialViewModel(MakelaarDomainModel domainModel, int positie)
        {
            if (domainModel == null)
            {
                this.logger.Error($"het domainModel is null");
                throw new ArgumentNullException(nameof(domainModel));
            }

            if (positie < 1)
            {
                this.logger.Error($"de positie is kleiner dan 1");
                throw new ArgumentOutOfRangeException(nameof(positie));
            }

            return this.makelaarPartialViewModelBuilder.Create(
                positie,
                domainModel.Naam,
                domainModel.TotaalAantalObjecten);
        }

    }
}