using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class FundaAanbodRestClient : IFundaAanbodRestClient
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(FundaAanbodRestClient));

        private readonly IFundaAanbodDtoAdapter adapter;

        public FundaAanbodRestClient(IFundaAanbodDtoAdapter adapter)
        {
            this.adapter = adapter;
        }

        private bool HasMore(FundaAanbodDto aanbodDto)
        {
            if (aanbodDto == null)
            {
                throw new ArgumentNullException(nameof(aanbodDto));
            }

            return aanbodDto.Paging.VolgendeUrl == null;
        }

        public List<FundaObject> GetAll(string link)
        {
            var paginanummer = 1;
            var totaalAanbod = new List<FundaObject>();

            while (true)
            {
                var linkNaarAmsterdamseKoopAanbodFunda = new Uri($"{link}/p{paginanummer}");
                this.logger.Info(linkNaarAmsterdamseKoopAanbodFunda);

                var aanbodDto =
                    SimpleAsyncHttpClientTask.RunAsync<FundaAanbodDto>(
                        linkNaarAmsterdamseKoopAanbodFunda,
                        new MediaTypeWithQualityHeaderValue("application/json"), this.adapter).Result;

                if (aanbodDto == null)
                {
                    break;
                }

                this.logger.Info(aanbodDto?.Paging.VolgendeUrl);
                this.logger.Info($"{totaalAanbod.Count} / {aanbodDto?.TotaalAantalObjecten}");

                paginanummer++;
                totaalAanbod.AddRange(aanbodDto.Objects);

                if (this.HasMore(aanbodDto))
                {
                    this.logger.Info($"{totaalAanbod.Count} / {aanbodDto.TotaalAantalObjecten}");

                    break;
                }
            }

            return totaalAanbod;
        }
    }
}