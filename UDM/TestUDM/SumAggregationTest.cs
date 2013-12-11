﻿using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
        ///A test for SumAggregation Constructor
        ///</summary>
        [TestMethod()]
        public void SumAggregationConstructorTest()
        {
            List<Cell> cells = null; // TODO: Initialize to an appropriate value
            SumAggregation target = new SumAggregation(cells);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetAggregatedValue
        ///</summary>
        [TestMethod()]
        public void GetAggregatedValueTest()
        {
            List<Cell> cells = null; // TODO: Initialize to an appropriate value
            SumAggregation target = new SumAggregation(cells); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.GetAggregatedValue();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
