using System;

using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class MakelaarDomainModelBuilder : IMakelaarDomainModelBuilder
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(MakelaarDomainModelBuilder));

        public MakelaarDomainModel Create(string id, string naam, int totaalAantalObjecten)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            if (string.IsNullOrEmpty(naam))
            {
                throw new ArgumentOutOfRangeException(nameof(naam));
            }

            if (totaalAantalObjecten < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(totaalAantalObjecten));
            }

            this.logger.Info($"We maken een makelaar aan met id: {id}, naam: {naam} en {totaalAantalObjecten} objecten");

            return new MakelaarDomainModel()
            {
                Id = id,
                Naam = naam,
                TotaalAantalObjecten = totaalAantalObjecten
            };
        }
    }
}