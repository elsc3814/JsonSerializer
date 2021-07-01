using NUnit.Framework;

namespace NUnitTestJsonSerializer
{
    public class JsonSerializerTest
    {
        private readonly JsonSerializer.JsonSerializer _sut = new JsonSerializer.JsonSerializer();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CorrectlySerializeString()
        {
            var result = _sut.Serialize(new {Name = "Ben"});
            Assert.AreEqual("{\"Name\":\"Ben\"}", result);
        }

        [Test]
        public void CorrectlySerializeInt()
        {
            var result = _sut.Serialize(new {Age = 22});
            Assert.AreEqual("{\"Age\":22}", result);
        }

        [Test]
        public void CorrectlySerializeStringAndIntProperties()
        {
            var result = _sut.Serialize(new {Age = 22, Name = "Ben"});
            Assert.AreEqual("{\"Age\":22,\"Name\":\"Ben\"}", result);
        }
    }
}