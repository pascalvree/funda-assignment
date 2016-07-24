using System;

using ConsoleApplication1.Implementations;
using ConsoleApplication1.Interfaces;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication1.Tests.Implementations
{
    [TestClass]
    public class MakelaarDtoBuilderTests : BaseTest
    {
        private readonly IMakelaarDtoBuilder builder = new MakelaarDtoBuilder();

        [TestMethod]
        public void DependencyInjectionTest()
        {
            var result = this.DiContainer.GetInstance<IMakelaarDtoBuilder>();

            Assert.AreEqual(typeof(MakelaarDtoBuilder), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionWhenCreatedWithNullAsIdArgumentTest()
        {
            this.builder.Create(null, "naam", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionWhenCreatedWithNullAsNaamArgumentTest()
        {
            this.builder.Create("id", null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionWhenCreatedWithEmptyStringAsIdArgumentTest()
        {
            this.builder.Create(string.Empty, "naam", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionWhenCreatedWithEmptyStringAsNaamArgumentTest()
        {
            this.builder.Create("id", string.Empty, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionWhenCreatedWithNegativeNumberAsTotaalAantalObjectenArgumentTest()
        {
            this.builder.Create("id", "naam", -1);
        }

        [TestMethod]
        public void CreatedWithExpectedValuesForArgumentsTest()
        {
            const string Id = "id";
            const string Naam = "naam";
            const int AantalObjecten = int.MaxValue;

            var result = this.builder.Create(Id, Naam, AantalObjecten);

            Assert.AreEqual(Id, result.Id);
            Assert.AreEqual(Naam, result.Naam);
            Assert.AreEqual(AantalObjecten, result.TotaalAantalObjecten);
        }
    }
}