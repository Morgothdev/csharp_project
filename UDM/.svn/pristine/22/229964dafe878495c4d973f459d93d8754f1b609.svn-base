using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;

namespace TestUDM
{
    
    
    /// <summary>
    ///This is a test class for SumAggregationTest and is intended
    ///to contain all SumAggregationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SumAggregationTest
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
            List<Cell> cells = new List<Cell>();
            for (int i = 0; i < 10; i++)
            {
                var cell = new Mock<Cell>();
                cell.Setup(foo => foo.Content).Returns(i);
                cells.Add(cell.Object);
            }
            SumAggregation target = new SumAggregation(cells);
            double expected = 49;
            double actual;
            actual = (double)target.GetAggregatedValue();
            Assert.AreEqual(expected, actual);
        }
    }
}
