using System.Collections.Generic;

using ConsoleApplication1.Models;

namespace ConsoleApplication1.Interfaces
{
    public interface IFundaObjectDtoConverter
    {
        IList<MakelaarDomainModel> ToMakelaarDomainModels(IEnumerable<FundaObject> aanbod);
    }
}