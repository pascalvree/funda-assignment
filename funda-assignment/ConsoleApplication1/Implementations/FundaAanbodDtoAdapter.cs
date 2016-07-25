using System;
using System.IO;
using System.Runtime.Serialization.Json;

using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class FundaAanbodDtoAdapter : IFundaAanbodDtoAdapter
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(FundaAanbodDtoAdapter));
        private readonly DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(FundaAanbodDto));

        public FundaAanbodDto Adapt(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var dto = this.serializer.ReadObject(stream) as FundaAanbodDto;
            if (dto == null)
            {
                throw new NullReferenceException(nameof(dto));
            }

            return dto;
        }
    }
}