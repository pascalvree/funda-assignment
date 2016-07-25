using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class FundaAanbodDtoAdapter : IFundaAanbodDtoAdapter
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(Application));

        private readonly DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(FundaAanbodDto));

        public FundaAanbodDto Adapt(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            try
            {
                return this.serializer.ReadObject(stream) as FundaAanbodDto;
            }
            catch (SerializationException exception)
            {
                this.logger.Error(exception);

                throw;
            }
        }
    }
}