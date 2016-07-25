using System.Collections.Generic;

using ConsoleApplication1.Models;

namespace ConsoleApplication1.Interfaces
{
    public interface IFundaAanbodRepository
    {
        List<FundaObject> GetAll(string link);
    }
}