using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

using log4net;

namespace ConsoleApplication1.Implementations
{
    internal class SimpleAsyncHttpClient
    {
        public static async Task<T> RunAsync<T>(Uri link, MediaTypeWithQualityHeaderValue mediaTypeHeaderValue, XmlObjectSerializer serializer) where T : class
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = link;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaTypeHeaderValue);

                var contents = await client.GetStreamAsync(link);

                return serializer.ReadObject(contents) as T;
            }
        }
    }

    public class FundaAanbodRestClient : IFundaAanbodRestClient
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(FundaAanbodRestClient));

        public List<FundaObject> GetAll(string link)
        {
            var paginanummer = 1;
            var totaalAanbod = new List<FundaObject>();

            while (true)
            {
                var linkNaarAmsterdamseKoopAanbodFunda = new Uri($"{link}/p{paginanummer}");
                this.logger.Info(linkNaarAmsterdamseKoopAanbodFunda);

                var amsterdamseKoopAanbod =
                    SimpleAsyncHttpClient.RunAsync<FundaAanbodDto>(
                        linkNaarAmsterdamseKoopAanbodFunda,
                        new MediaTypeWithQualityHeaderValue("application/json"),
                        new DataContractJsonSerializer(typeof(FundaAanbodDto))).Result;

                this.logger.Info(amsterdamseKoopAanbod.Paging.VolgendeUrl);
                this.logger.Info($"{totaalAanbod.Count} / {amsterdamseKoopAanbod.TotaalAantalObjecten}");

                paginanummer++;
                totaalAanbod.AddRange(amsterdamseKoopAanbod.Objects);
                if (amsterdamseKoopAanbod.Paging.VolgendeUrl == null)
                {
                    this.logger.Info($"{totaalAanbod.Count} / {amsterdamseKoopAanbod.TotaalAantalObjecten}");

                    break;
                }
            }

            return totaalAanbod;
        }
    }
}