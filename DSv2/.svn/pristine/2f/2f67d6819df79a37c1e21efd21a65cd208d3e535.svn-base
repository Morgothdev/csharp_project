using DSources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DSources.Parsers
{
    [TestClass]
    public class ParserArgumentInfoTests
    {
        [TestMethod]
        [TestCategory("ParserArgument")]
        [TestCategory("Implemented")]
        public void TestCohesionBetweenConstructorArgumentsAndValuesFromGetters()
        {
            ArgType type = ArgType.File;
            String name = "Name Of Argument";
            String dsc = "This is test argument";
            ParserArgumentInfo tested = new ParserArgumentInfo( name,type,dsc);
            Assert.AreEqual(tested.Name, name);
            Assert.AreEqual(type, tested.Type);
            Assert.AreEqual(dsc, tested.Description);
        }
    }
}
