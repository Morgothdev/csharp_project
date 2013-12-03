using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSources
{
    [TestClass]
    public class AcceptanceTests
    {
        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Not implemented")]
        public void ParsersCount()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            Assert.IsTrue(facade.GetParsersInfoAsCollection().Count == 4);
        }
    }
}
