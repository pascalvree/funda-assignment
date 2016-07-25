using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class FundaAanbodRepository : IFundaAanbodRepository
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(FundaAanbodRepository));

        private readonly IFundaAanbodDtoAdapter adapter;
        private readonly MediaTypeWithQualityHeaderValue header = new MediaTypeWithQualityHeaderValue("application/json");

        public FundaAanbodRepository(IFundaAanbodDtoAdapter adapter)
        {
            this.adapter = adapter;
        }

        private bool HasAnyLeft(FundaAanbodDto aanbodDto)
        {
            if (aanbodDto == null)
            {
                throw new ArgumentNullException(nameof(aanbodDto));
            }

            return aanbodDto?.Paging?.VolgendeUrl != null;
        }

        private void AddRange(IList<FundaObject> fundaObjects, List<FundaObject> totaalAanbod)
        {
            if (fundaObjects == null)
            {
                throw new ArgumentNullException(nameof(fundaObjects));
            }

            if (totaalAanbod == null)
            {
                throw new ArgumentNullException(nameof(totaalAanbod));
            }

            totaalAanbod.AddRange(fundaObjects);
        }

        private FundaAanbodDto GetPage(int paginanummer, string baseLink)
        {
            var link = new Uri($"{baseLink}/p{paginanummer}");
            return SimpleAsyncHttpClientTask.RunAsync<FundaAanbodDto>(link, this.header, this.adapter).Result;
        }

        public List<FundaObject> GetAll(string link)
        {
            var paginanummer = 0;
            var totaalAanbod = new List<FundaObject>();

            while (true)
            {
                paginanummer++;
                var aanbodDtoResponse = this.GetPage(paginanummer, link);

                this.AddRange(aanbodDtoResponse?.Objects, totaalAanbod);
                this.logger.Info($"{totaalAanbod.Count} / {aanbodDtoResponse?.TotaalAantalObjecten}");

                if (this.HasAnyLeft(aanbodDtoResponse)) continue;

                break;
            }

            return totaalAanbod;
        }
    }
}