using System;
using System.IO;
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
            Logger.Info(link);

            using (var client = new HttpClient())
            {
                client.BaseAddress = link;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaTypeHeaderValue);

                try
                {
                    var stream = await client.GetStreamAsync(link);
                    var memory = new MemoryStream();
                    stream.CopyTo(memory);
                    memory.Position = 0;

                    var reader = new StreamReader(memory);

                    SimpleAsyncHttpClientTask.Logger.Info(reader.ReadToEnd());
                    reader.BaseStream.Position = 0;

                    return adapter.Adapt(reader.BaseStream) as T;
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
