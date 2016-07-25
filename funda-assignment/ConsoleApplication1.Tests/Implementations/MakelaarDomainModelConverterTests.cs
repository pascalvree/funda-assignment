
using System;

using ConsoleApplication1.Implementations;
using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication1.Tests.Implementations
{
    [TestClass]
    public class MakelaarDomainModelConverterTests : BaseTest
    {
        private IMakelaarDomainModelConverter converter;

        [TestInitialize]
        public void TestInitialize()
        {
            this.converter = this.DiContainer.GetInstance<IMakelaarDomainModelConverter>();
        }

        [TestMethod]
        public void DependencyInjectionTest()
        {
            var result = this.DiContainer.GetInstance<IMakelaarDomainModelConverter>();

            Assert.AreEqual(typeof(MakelaarDomainModelConverter), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionWhenCalledWithNullAsDomainModelArgumentTest()
        {
            this.converter.ToMakelaarPartialViewModel(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionWhenCalledWithNegativeNumberAsPositieArgumentTest()
        {
            this.converter.ToMakelaarPartialViewModel(new MakelaarDomainModel(), -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentNullExceptionWhenCalledEmptyDomainModelAsDomainModelArgumentTest()
        {
            var domainModel = new MakelaarDomainModel();
            var result = this.converter.ToMakelaarPartialViewModel(domainModel, 0);
        }

        [TestMethod]
        public void WhenCalledEmptyDomainModelAsDomainModelArgumentTest()
        {
            const int Positie = 3;
            var domainModel = new MakelaarDomainModel() { Id = "Id", Naam = "Naam", TotaalAantalObjecten = 3 };
            var result = this.converter.ToMakelaarPartialViewModel(domainModel, Positie);

            Assert.AreEqual(Positie, result.Positie);
            Assert.AreEqual(domainModel.Naam, result.Naam);
            Assert.AreEqual(domainModel.TotaalAantalObjecten, result.TotaalAantalObjecten);
        }
    }
}