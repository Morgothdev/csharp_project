using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;

namespace TestUDM
{
    
    
    /// <summary>
    ///This is a test class for CountAggregationTest and is intended
    ///to contain all CountAggregationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CountAggregationTest
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
        ///A test for GetAggregatedValue
        ///</summary>
        [TestMethod()]
        public void GetAggregatedValueTest()
        {
            var cell1 = new Mock<Cell>();
            var cell2 = new Mock<Cell>();
            var cell3 = new Mock<Cell>();
            List<Cell> cells = new List<Cell>();
            cells.Add(cell1.Object);
            cells.Add(cell2.Object);
            CountAggregation target = new CountAggregation(cells);
            double expected = 2;
            double actual;
            actual = (double)target.GetAggregatedValue();
            Assert.AreEqual(expected, actual);

            cells.Add(cell3.Object);
            expected = 3;
            actual = (double)target.GetAggregatedValue();
            Assert.AreEqual(expected, actual);
        }
    }
}
