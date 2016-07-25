
using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleApplication1.Implementations;
using ConsoleApplication1.Interfaces;
using ConsoleApplication1.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication1.Tests.Implementations
{
    [TestClass]
    public class MakelaarDomainModelIListConverterTests : BaseTest
    {
        private IMakelaarDomainModelIListConverter converter;

        [TestInitialize]
        public void TestInitialize()
        {
            this.converter = this.DiContainer.GetInstance<IMakelaarDomainModelIListConverter>();
        }

        [TestMethod]
        public void DependencyInjectionTest()
        {
            var result = this.DiContainer.GetInstance<IMakelaarDomainModelIListConverter>();

            Assert.AreEqual(typeof(MakelaarDomainModelIListConverter), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionWhenCalledWithNullArgumentTest()
        {
            this.converter.ToMakelaarPartialViewModels(null);
        }

        [TestMethod]
        public void EmptyResultWhenCalledWithAnEmptyCollectionTest()
        {
            var domainModels = new List<MakelaarDomainModel>();
            var result = this.converter.ToMakelaarPartialViewModels(domainModels);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionWhenCalledWithAnNUllEntryInCollectionTest()
        {
            var domainModels = new List<MakelaarDomainModel>() { null };
            var result = this.converter.ToMakelaarPartialViewModels(domainModels);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionWhenCalledWithAnEmptyEntryInCollectionTest()
        {
            var makelaarDomainModel = new MakelaarDomainModel();
            var domainModels = new List<MakelaarDomainModel>() { makelaarDomainModel };
            var result = this.converter.ToMakelaarPartialViewModels(domainModels);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void ArgumentOutOfRangeExceptionWhenCalledWithAValidEntryInCollectionTest()
        {
            var makelaarDomainModel = new MakelaarDomainModel() { Id = "Id", Naam = "Naam", TotaalAantalObjecten = 3 };
            var domainModels = new List<MakelaarDomainModel>() { makelaarDomainModel };
            var result = this.converter.ToMakelaarPartialViewModels(domainModels);
            Assert.IsTrue(result.Any());
        }
    }
}