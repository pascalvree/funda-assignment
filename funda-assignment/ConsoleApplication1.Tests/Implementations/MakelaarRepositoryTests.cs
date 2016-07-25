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
    public class MakelaarRepositoryTests : BaseTest
    {
        private MakelaarDomainModel CreateMakelaar(int index)
        {
            return new MakelaarDomainModel()
            {
                Id = index.ToString(),
                Naam = index.ToString(),
                TotaalAantalObjecten = index
            };
        }

        private IEnumerable<MakelaarDomainModel> CreateMakelaars(int aantalMakelaars)
        {
            return Enumerable.Range(1, aantalMakelaars).Select(this.CreateMakelaar).ToList();
        }

        [TestMethod]
        public void DependencyInjectionTest()
        {
            var result = this.DiContainer.GetInstance<IMakelaarRepository>();

            Assert.AreEqual(typeof(MakelaarRepository), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionWhenUsingNullAsDomainModelsArgumentTest()
        {
            new MakelaarRepository().Add(null);
        }

        [TestMethod]
        public void GetTop10IsEmptyWhenCreatedWith0MakelaarsTest()
        {
            var repository = new MakelaarRepository();
            repository.Add(new List<MakelaarDomainModel>());

            Assert.IsFalse(repository.Take(1).Any());
        }

        [TestMethod]
        public void GetTop10Has1MakelaarWhenCreatedWith3MakelaarTest()
        {
            const int AantalMakelaars = 3;
            var repository = new MakelaarRepository();
            repository.Add(this.CreateMakelaars(AantalMakelaars));
            Assert.AreEqual(AantalMakelaars, repository.Take(AantalMakelaars).Count());
        }

        [TestMethod]
        public void GetTop10WhenCreatedWith22MakelaarTest()
        {
            const int AantalMakelaars = 22;
            var repository = new MakelaarRepository();
            repository.Add(this.CreateMakelaars(AantalMakelaars));
            Assert.AreEqual(10, repository.Take(10).Count());
        }

        [TestMethod]
        public void ClearRepositoryTest()
        {
            const int AantalMakelaars = 3;
            var repository = new MakelaarRepository();
            repository.Add(this.CreateMakelaars(AantalMakelaars));
            Assert.AreEqual(AantalMakelaars, repository.Take(AantalMakelaars).Count());
            repository.Clear();
            Assert.AreEqual(0, repository.Take(AantalMakelaars).Count());
        }
    }
}