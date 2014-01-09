using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSources.Parsers
{
    [TestClass]
    public class StubParserTest
    {
        StubParser tested;

        [TestInitialize]
        public void setUp()
        {
            tested = new StubParser();
        }


        [TestMethod]
        [TestCategory("StubParser")]
        public void TestClonePrototypeShouldThrowException()
        {
            try
            {
                tested.ClonePrototype();
            }
            catch (NotSupportedException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("StubParser")]
        public void TestConfigureItSelf()
        {
            try
            {
                tested.ConfigureItSelf(null);
            }
            catch (NotSupportedException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("StubParser")]
        public void TestParse()
        {
            try
            {
                tested.Parse();
            }
            catch (NotSupportedException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("StubParser")]
        public void TestInit()
        {
            try
            {
                tested.Init();
            }
            catch (NotSupportedException)
            {
                return;
            }
            Assert.Fail();
        }
    }
}
