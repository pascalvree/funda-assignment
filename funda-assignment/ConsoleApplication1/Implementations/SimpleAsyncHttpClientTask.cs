using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using ConsoleApplication1.Interfaces;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class SimpleAsyncHttpClientTask : ISimpleAsyncHttpClientTask
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(SimpleAsyncHttpClientTask));

        public static async Task<T> RunAsync<T>(Uri link, MediaTypeWithQualityHeaderValue mediaTypeHeaderValue, IAdapter<T> adapter) where T : class
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = link;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaTypeHeaderValue);

                try
                {
                    var stream = await client.GetStreamAsync(link);
                    SimpleAsyncHttpClientTask.Logger.Info(stream);

                    return adapter.Adapt(stream) as T;
                }
                catch (WebException exception)
                {
                    SimpleAsyncHttpClientTask.Logger.Error(exception);

                    throw;
                }
            }
        }
    }
}
