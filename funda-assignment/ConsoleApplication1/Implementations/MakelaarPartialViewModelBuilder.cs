using System;

using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class MakelaarPartialViewModelBuilder : IMakelaarPartialViewModelBuilder
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(MakelaarPartialViewModelBuilder));

        public MakelaarPartialViewModel Create(int positie, string naam, int totaalAantalObjecten)
        {
            if (positie <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(positie));
            }

            if (string.IsNullOrEmpty(naam))
            {
                throw new ArgumentOutOfRangeException(nameof(naam));
            }

            if (totaalAantalObjecten < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(totaalAantalObjecten));
            }

            this.logger.Info($"We maken een makelaar aan met positie: {positie}, naam: {naam} en {totaalAantalObjecten} objecten");

            return new MakelaarPartialViewModel()
            {
                Naam = naam,
                Positie = positie,
                TotaalAantalObjecten = totaalAantalObjecten
            };
        }
    }
}