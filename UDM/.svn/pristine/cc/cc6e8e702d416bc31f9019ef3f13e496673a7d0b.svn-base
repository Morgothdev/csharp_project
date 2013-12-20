using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;

namespace TestUDM
{
    
    
    /// <summary>
    ///This is a test class for ColumnTest and is intended
    ///to contain all ColumnTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ColumnTest
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
        ///A test for AddCell
        ///</summary>
        [TestMethod()]
        public void AddCellTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            DataType type = new DataType(); // TODO: Initialize to an appropriate value
            List<Cell> cells = null; // TODO: Initialize to an appropriate value
            Column target = new Column(name, type, cells); // TODO: Initialize to an appropriate value
            Cell cell = null; // TODO: Initialize to an appropriate value
            target.AddCell(cell);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RemoveCell
        ///</summary>
        [TestMethod()]
        public void RemoveCellTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            DataType type = new DataType(); // TODO: Initialize to an appropriate value
            List<Cell> cells = null; // TODO: Initialize to an appropriate value
            Column target = new Column(name, type, cells); // TODO: Initialize to an appropriate value
            Cell cell = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.RemoveCell(cell);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            //kolumna integerów
            string name = "Nazwa";
            List<Cell> cells = new List<Cell>();
            var cell1 = new Mock<Cell>();
            var cell2 = new Mock<Cell>();
            var cell3 = new Mock<Cell>();
            var cell4 = new Mock<Cell>();
            cell1.Setup(foo => foo.ToString()).Returns("5");
            cell2.Setup(foo => foo.ToString()).Returns("6");
            cell3.Setup(foo => foo.ToString()).Returns("7");
            cell4.Setup(foo => foo.ToString()).Returns("1");
            cells.Add(cell1.Object);
            cells.Add(cell2.Object);
            cells.Add(cell3.Object);
            cells.Add(cell4.Object);
            Column target = new Column(name, DataType.IntegerFact, cells);
            string expected = name + "\n5 6 7 1 ";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            //kolumna stringów
            cell1.Setup(foo => foo.ToString()).Returns("pięć");
            cell2.Setup(foo => foo.ToString()).Returns("sześć");
            cell3.Setup(foo => foo.ToString()).Returns("siedem");
            cell4.Setup(foo => foo.ToString()).Returns("jeden");
            cells = new List<Cell>();
            cells.Add(cell1.Object);
            cells.Add(cell2.Object);
            cells.Add(cell3.Object);
            cells.Add(cell4.Object);
            target = new Column(name, DataType.StringDimension, cells);
            expected = name + "\npięć sześć siedem jeden ";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Cells
        ///</summary>
        [TestMethod()]
        public void CellsTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            DataType type = new DataType(); // TODO: Initialize to an appropriate value
            List<Cell> cells = null; // TODO: Initialize to an appropriate value
            Column target = new Column(name, type, cells); // TODO: Initialize to an appropriate value
            List<Cell> expected = null; // TODO: Initialize to an appropriate value
            List<Cell> actual;
            target.Cells = expected;
            actual = target.Cells;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            DataType type = new DataType(); // TODO: Initialize to an appropriate value
            List<Cell> cells = null; // TODO: Initialize to an appropriate value
            Column target = new Column(name, type, cells); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        public void TypeTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            DataType type = new DataType(); // TODO: Initialize to an appropriate value
            List<Cell> cells = null; // TODO: Initialize to an appropriate value
            Column target = new Column(name, type, cells); // TODO: Initialize to an appropriate value
            DataType actual;
            actual = target.Type;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
