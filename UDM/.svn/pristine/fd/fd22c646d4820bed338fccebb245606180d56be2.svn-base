using UDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;

namespace TestUDM
{
    
    
    /// <summary>
    ///This is a test class for VerticalJoinCommandTest and is intended
    ///to contain all VerticalJoinCommandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VerticalJoinCommandTest
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
            var table = new Mock<Table>();
            var table2 = new Mock<Table>();
            
            var cell1 = new Mock<Cell>();
            var cell2 = new Mock<Cell>();
            var cell3 = new Mock<Cell>();
            var cell4 = new Mock<Cell>();
            var cell5 = new Mock<Cell>();
            var cell6 = new Mock<Cell>();
            var cell7 = new Mock<Cell>();
            var cell8 = new Mock<Cell>();

            List<Cell> list1 = new List<Cell>();
            List<Cell> list2 = new List<Cell>();
            List<Cell> list3 = new List<Cell>();
            List<Cell> list4 = new List<Cell>();

            list1.Add(cell1.Object);
            list1.Add(cell2.Object);
            list2.Add(cell3.Object);
            list2.Add(cell4.Object);
            list3.Add(cell5.Object);
            list3.Add(cell6.Object);
            list4.Add(cell7.Object);

            var column1 = new Mock<Column>();
            var column2 = new Mock<Column>();
            var column3 = new Mock<Column>();
            var column4 = new Mock<Column>();

            column1.Setup(foo => foo.Cells).Returns(list1);
            column2.Setup(foo => foo.Cells).Returns(list2);
            column3.Setup(foo => foo.Cells).Returns(list3);
            column4.Setup(foo => foo.Cells).Returns(list4);

            List<Column> columns1 = new List<Column>();
            List<Column> columns2 = new List<Column>();

            columns1.Add(column1.Object);
            columns1.Add(column2.Object);
            columns2.Add(column3.Object);
            columns2.Add(column4.Object);

            //to są dwie tabele do połączenia
            table.Setup(foo => foo.Columns).Returns(columns1);
            table2.Setup(foo => foo.Columns).Returns(columns2);

            VerticalJoinCommand target = new VerticalJoinCommand(table2.Object);

            var table3 = new Mock<Table>(); //taką tabelę będziemy chcieli uzyskać

            //to są kolumny tabeli, którą chcemy uzyskać
            var column5 = new Mock<Column>();
            var column6 = new Mock<Column>();

            List<Cell> list5 = new List<Cell>();
            list5.AddRange(list1);
            list5.AddRange(list3);
            column5.Setup(foo => foo.Cells).Returns(list5);

            List<Cell> list6 = new List<Cell>();
            list6.AddRange(list2);
            list6.AddRange(list4);
            column6.Setup(foo => foo.Cells).Returns(list6);

            List<Column> columns3 = new List<Column>(); //lista kolumn tabeli, którą chcemy uzyskać
            
            table3.Setup(foo => foo.Columns).Returns(columns3); //gotowy mock tabeli
            

            Assert.AreEqual(table3.Object.Columns, target.Execute(table.Object));

        }
    }
}
