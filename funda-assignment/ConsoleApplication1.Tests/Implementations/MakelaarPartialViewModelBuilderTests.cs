using System;

using ConsoleApplication1.Implementations;
using ConsoleApplication1.Interfaces;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication1.Tests.Implementations
{
    [TestClass]
    public class MakelaarPartialViewModelBuilderTests : BaseTest
    {
        private readonly IMakelaarPartialViewModelBuilder builder = new MakelaarPartialViewModelBuilder();

        [TestMethod]
        public void DependencyInjectionTest()
        {
            var result = this.DiContainer.GetInstance<IMakelaarPartialViewModelBuilder>();

            Assert.AreEqual(typeof(MakelaarPartialViewModelBuilder), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionWhenCreatedWith0AsPositieArgumentTest()
        {
            this.builder.Create(0, "naam", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionWhenCreatedWithNullAsNaamArgumentTest()
        {
            this.builder.Create(1, null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionWhenCreatedWithNegativeNumbergAsPositieArgumentTest()
        {
            this.builder.Create(-1, "naam", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionWhenCreatedWithEmptyStringAsNaamArgumentTest()
        {
            this.builder.Create(1, string.Empty, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionWhenCreatedWithNegativeNumberAsTotaalAantalObjectenArgumentTest()
        {
            this.builder.Create(1, "naam", -1);
        }

        [TestMethod]
        public void CreatedWithExpectedValuesForArgumentsTest()
        {
            const int Positie = 2;
            const string Naam = "naam";
            const int AantalObjecten = int.MaxValue;

            var result = this.builder.Create(Positie, Naam, AantalObjecten);

            Assert.AreEqual(Positie, result.Positie);
            Assert.AreEqual(Naam, result.Naam);
            Assert.AreEqual(AantalObjecten, result.TotaalAantalObjecten);
        }
    }
}