using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;

namespace TestUDM
{
    
    
    /// <summary>
    ///This is a test class for SelectCommandTest and is intended
    ///to contain all SelectCommandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SelectCommandTest
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
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            //po referencjach do kolumn
            List<Column> originalColumns = new List<Column>();
            var column1 = new Mock<Column>();
            var column2 = new Mock<Column>();
            var column3 = new Mock<Column>(); 
            originalColumns.Add(column1.Object);
            originalColumns.Add(column2.Object);
            originalColumns.Add(column3.Object);
            List<Column> selectedColumns = new List<Column>();
            selectedColumns.Add(column1.Object);
            selectedColumns.Add(column3.Object);
            SelectCommand target = new SelectCommand(selectedColumns);
            var table = new Mock<Table>(); //tabela oryginalna
            var table2 = new Mock<Table>(); //tabela, która powinna powstać
            table.Setup(foo => foo.Columns).Returns(originalColumns);
            table2.Setup(foo => foo.Columns).Returns(selectedColumns);
            List<Column> receivedColumns = target.Execute(table.Object).Columns;
            Assert.AreEqual(table2.Object.Columns, receivedColumns);
            
            //po indeksach
            List<int> selectedIndeces = new List<int>();
            selectedIndeces.Add(0);
            selectedIndeces.Add(2);
            target = new SelectCommand(selectedIndeces);
            receivedColumns = target.Execute(table.Object).Columns;
            Assert.AreEqual(table2.Object.Columns, receivedColumns);

        }
    }
}
