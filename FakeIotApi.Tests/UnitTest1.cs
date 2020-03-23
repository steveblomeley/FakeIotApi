using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass("Test passed");
        }

        //[Test]
        //public void Test2()
        //{
        //    Assert.Fail("Test failed");
        //}

        //[Test]
        //[Ignore("Test ignored")]
        //public void Test3()
        //{
        //    Assert.Pass();
        //}
    }
}