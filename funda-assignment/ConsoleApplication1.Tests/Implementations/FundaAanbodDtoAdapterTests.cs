
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

using ConsoleApplication1.Implementations;
using ConsoleApplication1.Interfaces;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication1.Tests.Implementations
{
    [TestClass]
    public class FundaAanbodDtoAdapterTests : BaseTest
    {
        private readonly IFundaAanbodDtoAdapter adapter = new FundaAanbodDtoAdapter();

        [TestMethod]
        public void DependencyInjectionTest()
        {
            var result = this.DiContainer.GetInstance<IFundaAanbodDtoAdapter>();

            Assert.AreEqual(typeof(FundaAanbodDtoAdapter), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionWhenCalledWithNullTest()
        {
            this.adapter.Adapt(null);
        }

        [TestMethod]
        [ExpectedException(typeof(SerializationException))]
        public void WhenCalledWithEmptyResponseTest()
        {
            this.adapter.Adapt(new MemoryStream());
        }

        [TestMethod]
        [ExpectedException(typeof(SerializationException))]
        public void WhenCalledWithPartialResponseTest()
        {
            var buffer = Encoding.ASCII.GetBytes("");

            var stream = new MemoryStream();
            stream.Write(buffer: buffer, offset: 0, count: buffer.Length);
            this.adapter.Adapt(stream);
        }

        [TestMethod]
        [ExpectedException(typeof(SerializationException))]
        public void WhenCalledWithUnexpectedResponseTest()
        {
            var buffer = Encoding.ASCII.GetBytes("ab");

            var stream = new MemoryStream();
            stream.Write(buffer: buffer, offset: 0, count: buffer.Length);
            this.adapter.Adapt(stream);
        }

        [TestMethod]
        [ExpectedException(typeof(SerializationException))]
        public void WhenCalledWithValidButEmptyResponseTest()
        {
            var buffer = Encoding.ASCII.GetBytes("{}");

            var stream = new MemoryStream();
            stream.Write(buffer: buffer, offset: 0, count: buffer.Length);
            this.adapter.Adapt(stream);
        }

        [TestMethod]
        public void WhenCalledWithCompleteAndValidResponseTest()
        {
            const string ResourceName = "ConsoleApplication1.Tests.TestData.funda.aanbod.valid.response.json";

            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(ResourceName))
            {
                var streamReader = new StreamReader(stream);
                var content = Encoding.UTF8.GetBytes(streamReader.ReadToEnd());

                var result = this.adapter.Adapt(new MemoryStream(content));
                Assert.AreEqual(3676, result.TotaalAantalObjecten);
            }
        }
    }
}