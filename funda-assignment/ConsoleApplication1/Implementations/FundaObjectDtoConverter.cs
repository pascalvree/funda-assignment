using System.Collections.Generic;
using System.Linq;

using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

namespace ConsoleApplication1.Implementations
{
    public class FundaObjectDtoConverter : IFundaObjectDtoConverter
    {
        private readonly IMakelaarDomainModelBuilder makelaarDomainModelBuilder;

        public FundaObjectDtoConverter(IMakelaarDomainModelBuilder makelaarDomainModelBuilder)
        {
            this.makelaarDomainModelBuilder = makelaarDomainModelBuilder;
        }

        public IList<MakelaarDomainModel> ToMakelaarDomainModels(IEnumerable<FundaObject> aanbod)
        {
            return aanbod.Select(fundaObject => new { Id = fundaObject.MakelaarId, Naam = fundaObject.MakelaarNaam }).GroupBy(makelaar => makelaar.Id).Select(makelaar => this.makelaarDomainModelBuilder.Create(makelaar.Key.ToString(), makelaar.First().Naam, makelaar.Count())).OrderByDescending(makelaar => makelaar.TotaalAantalObjecten).ToList();
        }
    }
}