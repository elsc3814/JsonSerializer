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

        [Test]
        public void CorrectlySerializeArray()
        {
            var result = _sut.Serialize(new {IsNew = new[] {4, 5}});
            Assert.AreEqual("{\"IsNew\":[4,5]}", result);
        }

        [Test]
        public void CorrectlySerializeEmptyArray()
        {
            var result = _sut.Serialize(new {IsNew = new int[] { }});
            Assert.AreEqual("{\"IsNew\":[]}", result);
        }

        [Test]
        public void CorrectlySerialize2DArray()
        {
            var result = _sut.Serialize(new {IsNew = new[] {new[] {1, 2}, new[] {3, 4}}});
            Assert.AreEqual("{\"IsNew\":[[1,2],[3,4]]}", result);
        }

        [Test]
        public void CorrectlySerializeVariousArrays()
        {
            var result = _sut.Serialize(
                new
                {
                    @string = new[] {"just", "string"},
                    @bool = new[] {false, true},
                    @float = new[] {1.2f, 1.4f}
                });
            Assert.AreEqual("{\"string\":[\"just\",\"string\"],\"bool\":[false,true],\"float\":[1.2,1.4]}", result);
        }
    }
}