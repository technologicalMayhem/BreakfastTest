using NUnit.Framework;

namespace BreakfastTestTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestBreakfast()
        {
            BreakfastTest.Program.Main(new string[0]).Wait();
            Assert.Pass();
        }
    }
}