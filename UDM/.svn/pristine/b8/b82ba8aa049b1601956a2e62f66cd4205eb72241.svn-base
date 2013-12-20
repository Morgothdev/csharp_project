using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestUDM
{
    
    
    /// <summary>
    ///This is a test class for CellTest and is intended
    ///to contain all CellTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CellTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion



        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Cell target = new Cell(5.5);
            string expected = "5.5";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            target = new Cell("Ziemniak");
            expected = "Ziemniak";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Content
        ///</summary>
        [TestMethod()]
        public void ContentTest()
        {
            Cell target = new Cell(5);
            object expected = 5;
            object actual;
            target.Content = expected;
            actual = target.Content;
            Assert.AreEqual(expected, actual);
        }
    }
}
