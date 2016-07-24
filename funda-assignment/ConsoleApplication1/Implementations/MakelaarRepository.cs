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
        private readonly IEnumerable<MakelaarDto> makelaars;

        public MakelaarRepository(IEnumerable<MakelaarDto> makelaars)
        {
            if (makelaars == null)
            {
                throw new ArgumentNullException(nameof(makelaars));
            }

            this.makelaars = makelaars;
            this.logger.Info(message: $"Aangemaakt met {this.makelaars.Count()} makelaars");
        }

        public IEnumerable<MakelaarDto> Top10()
        {
            return this.makelaars.Take(10);
        }
    }
}