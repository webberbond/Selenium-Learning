using NUnit.Framework;

namespace SeleniumLeaarning
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("The setup method!");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("The test method!");
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.Progress.WriteLine("The teardown method!");
        }
    }
}