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

        [Test]
        public void CorrectlySerializeDouble()
        {
            var result = _sut.Serialize(new {Price = 22.55});
            Assert.AreEqual("{\"Price\":22.55}", result);
        }

        [Test]
        public void CorrectlySerializeFloat()
        {
            var result = _sut.Serialize(new {Price = 22.666f});
            Assert.AreEqual("{\"Price\":22.666}", result);
        }

        [Test]
        public void CorrectlySerializeDecimal()
        {
            var result = _sut.Serialize(new {Price = (decimal) 22.666});
            Assert.AreEqual("{\"Price\":22.666}", result);
        }

        [Test]
        public void CorrectlySerializeTrue()
        {
            var result = _sut.Serialize(new {IsNew = true});
            Assert.AreEqual("{\"IsNew\":true}", result);
        }

        [Test]
        public void CorrectlySerializeFalse()
        {
            var result = _sut.Serialize(new {IsNew = false});
            Assert.AreEqual("{\"IsNew\":false}", result);
        }
    }
}