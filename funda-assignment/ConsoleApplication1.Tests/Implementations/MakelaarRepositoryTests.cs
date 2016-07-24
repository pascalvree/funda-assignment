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
        private MakelaarDto CreateMakelaar(int index)
        {
            return new MakelaarDto();
        }

        [TestMethod]
        public void DependencyInjectionTest()
        {
            var result = this.DiContainer.GetInstance<IMakelaarRepository>();

            Assert.AreEqual(typeof(MakelaarRepository), result.GetType());
            Assert.IsFalse(result.Top10().Any());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionWhenCreatedWithNullArgumentTest()
        {
            var repository = new MakelaarRepository(null);
        }

        [TestMethod]
        public void GetTop10IsEmptyWhenCreatedWith0MakelaarsTest()
        {
            var repository = new MakelaarRepository(new List<MakelaarDto>());
            Assert.IsFalse(repository.Top10().Any());
        }

        [TestMethod]
        public void GetTop10Has1MakelaarWhenCreatedWith3MakelaarTest()
        {
            var aantalMakelaars = 3;
            var makelaars = Enumerable.Range(1, aantalMakelaars).Select(this.CreateMakelaar);
            var repository = new MakelaarRepository(makelaars);
            Assert.AreEqual(aantalMakelaars, repository.Top10().Count());
        }

        [TestMethod]
        public void GetTop10WhenCreatedWith22MakelaarTest()
        {
            var aantalMakelaars = 22;
            var makelaars = Enumerable.Range(1, aantalMakelaars).Select(this.CreateMakelaar);
            var repository = new MakelaarRepository(makelaars);

            Assert.AreEqual(10, repository.Top10().Count());
        }
    }
}