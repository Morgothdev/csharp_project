using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSources.Logic;

namespace DSources.Parsers
{
    class FullAbstractParser : AbstractParser
    {
        internal override void Read()
        {
            throw new NotImplementedException();
        }

        internal override InternalParser ClonePrototype()
        {
            throw new NotImplementedException();
        }
    }


    [TestClass]
    public class AbstractParserTest
    {

        AbstractParser tested;

        [TestInitialize]
        public void setUp()
        {
            tested = new FullAbstractParser();
        }

        [TestMethod]
        [TestCategory("AbstractParser")]
        public void TestExceptionOnArgumentsSet()
        {
            try
            {
                tested.Arguments = new ParserInfo();
                Assert.Fail("expect NotSupportedException");
            }
            catch (NotSupportedException) { }
        }

        [TestMethod]
        [TestCategory("AbstractParser")]
        public void TestExceptionOnParseNotValidParser()
        {
            try
            {
                tested.Init();
                tested.ConfigureItSelf(ParserConfiguration.GetBuilder().SetParserName("test").Build());
                Assert.Fail("expect Exception");
            }
            catch (Exception) { }
        }

    }
}
