using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class MakelaarDomainModelIListConverter : IMakelaarDomainModelIListConverter
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(MakelaarDomainModelIListConverter));
        private readonly IMakelaarDomainModelConverter makelaarDomainModelConverter;

        public MakelaarDomainModelIListConverter(IMakelaarDomainModelConverter makelaarDomainModelConverter)
        {
            this.makelaarDomainModelConverter = makelaarDomainModelConverter;
        }

        public IEnumerable<MakelaarPartialViewModel> ToMakelaarPartialViewModels(IList<MakelaarDomainModel> domainModels)
        {
            if (domainModels == null)
            {
                this.logger.Error($"de domainModels zijn null");
                throw new ArgumentNullException(nameof(domainModels));
            }

            var aantalDomainModels = domainModels.Count();
            this.logger.Info($"We converteren {aantalDomainModels} Makelaar DomainModels naar {aantalDomainModels} PartialViewModels");

            return domainModels.Zip(
                Enumerable.Range(1, aantalDomainModels).ToList(),
                this.makelaarDomainModelConverter.ToMakelaarPartialViewModel);
        }
    }
}