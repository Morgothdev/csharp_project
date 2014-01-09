using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSources.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;

namespace DSources.Parsers
{
    [TestClass]
    public class ParserBridgeTests
    {
        Mockery mockery = new Mockery();
        InternalParser mockParser;
        ParserBridge tested;
        ICollection<string> problems = new List<String>();

        [TestInitialize]
        public void setUp()
        {
            mockParser = (InternalParser)mockery.NewMock(typeof(InternalParser));
            tested = new ParserBridge { parser = mockParser };
        }

        [TestCleanup]
        public void cleanUp()
        {
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        [TestCategory("ParserBridge")]
        public void ParseTest()
        {
            Expect.Once.On(mockParser).GetProperty("Problems").Will(Return.Value(problems));
            Assert.AreEqual(tested.Problems, problems);
        }
    }
}
