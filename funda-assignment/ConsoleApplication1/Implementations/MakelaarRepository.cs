using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class MakelaarRepository : IMakelaarRepository
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(MakelaarRepository));
        private readonly List<MakelaarDomainModel> makelaars = new List<MakelaarDomainModel>();

        public void Add(IEnumerable<MakelaarDomainModel> domainModels)
        {
            if (domainModels == null)
            {
                throw new ArgumentNullException(nameof(domainModels));
            }

            this.makelaars.AddRange(domainModels);
            this.logger.Info(message: $"{this.makelaars.Count()} makelaars opgeslagen");
        }

        public IEnumerable<MakelaarDomainModel> Top10()
        {
            return this.makelaars.Take(10);
        }
    }
}