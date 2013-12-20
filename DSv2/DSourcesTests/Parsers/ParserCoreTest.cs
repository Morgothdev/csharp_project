using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSources.Parsers
{
    [TestClass]
    public class ParserCoreTest
    {
        ParserCore tested;

        [TestInitialize]
        public void Init()
        {
            tested = new ParserCore();
            tested.Init();
        }

        [TestMethod]
        [TestCategory("ParserCore")]
        [TestCategory("Implemented")]
        public void InitializingTest()
        {
            Assert.AreEqual(tested.columns.Count, 1);
            Assert.AreEqual(tested.columnNames.Count, 0);
            Assert.AreEqual(tested.columnDataTypes.Count, 0);
        }

        [TestMethod]
        [TestCategory("ParserCore")]
        [TestCategory("Implemented")]
        public void SettingNamesAndOrder()
        {
            tested.SetColumnName("pierwsza");
            tested.SetColumnName("druga");
            tested.SetColumnName("trzecia");
            Assert.AreEqual(tested.columnNames.Count, 3);
            Assert.AreEqual(tested.columnNames[0], "pierwsza");
            Assert.AreEqual(tested.columnNames[1], "druga");
            Assert.AreEqual(tested.columnNames[2], "trzecia");
        }

        [TestMethod]
        [TestCategory("ParserCore")]
        [TestCategory("Implemented")]
        public void SettingTypesAndOrder()
        {
            tested.SetColumnType(DataType.FloatFact);
            tested.SetColumnType(DataType.IntegerFact);
            tested.SetColumnType(DataType.StringDimension);
            Assert.AreEqual(tested.columnDataTypes.Count, 3);
            Assert.AreEqual(tested.columnDataTypes[0], DataType.FloatFact);
            Assert.AreEqual(tested.columnDataTypes[1], DataType.IntegerFact);
            Assert.AreEqual(tested.columnDataTypes[2], DataType.StringDimension);
        }


        [TestMethod]
        [TestCategory("ParserCore")]
        [TestCategory("Implemented")]
        public void SettingDoubleColumnNameAndType()
        {
            tested.SetColumnName("pierwsza");
            tested.SetColumnName("druga");
            tested.SetColumnType(DataType.IntegerFact);
            tested.SetColumnType(DataType.StringDimension);
            Assert.AreEqual(tested.columnNames[0], "pierwsza");
            Assert.AreEqual(tested.columnNames[1], "druga");
            Assert.AreEqual(tested.columnDataTypes.Count, 2);
            Assert.AreEqual(tested.columnNames.Count, 2);
            Assert.AreEqual(tested.columnDataTypes[0], DataType.IntegerFact);
            Assert.AreEqual(tested.columnDataTypes[1], DataType.StringDimension);
        }

        [TestMethod]
        [TestCategory("ParserCore")]
        [TestCategory("Implemented")]
        public void SettingInvalidColumnTypesWithOneRow_IS_THROWING_EXCEPTION()
        {
            tested.SetColumnName("pierwsza");
            tested.SetColumnName("druga");
            tested.SetColumnType(DataType.IntegerFact);
            tested.AddCellInRowAndGoToNextColumn("pierwsza-komorka");
            tested.AddCellInRowAndGoToNextColumn("druga-komorka");
            try
            {
                tested.Build();
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(e.Message.Contains("Different"));                
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("ParserCore")]
        [TestCategory("Implemented")]
        public void SettingInvalidColumnNamesWithOneRow_IS_THROWING_EXCEPTION()
        {
            tested.SetColumnName("pierwsza");
            tested.SetColumnType(DataType.IntegerFact);
            tested.SetColumnType(DataType.StringDimension);
            tested.AddCellInRowAndGoToNextColumn("pierwsza-komorka");
            tested.AddCellInRowAndGoToNextColumn("druga-komorka");
            try
            {
                tested.Build();
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(e.Message.Contains("Different"));                
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("ParserCore")]
        [TestCategory("Implemented")]
        public void SettingInvalidRowLength_IS_THROWING_EXCEPTION()
        {
            tested.SetColumnName("pierwsza");
            tested.SetColumnName("druga");
            tested.SetColumnType(DataType.IntegerFact);
            tested.SetColumnType(DataType.StringDimension);
            tested.AddCellInRowAndGoToNextColumn("pierwsza-komorka");
            try
            {
                tested.Build();
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(e.Message.Contains("Different"));                
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("ParserCore")]
        [TestCategory("Implemented")]
        public void SettingInvalidColumnLength_IS_THROWING_EXCEPTION()
        {
            tested.SetColumnName("pierwsza");
            tested.SetColumnName("druga");
            tested.SetColumnType(DataType.IntegerFact);
            tested.SetColumnType(DataType.StringDimension);
            tested.AddCellInRowAndGoToNextColumn("pierwsza-komorka_r1");
            tested.AddCellInRowAndGoToNextColumn("druga-komorka_r1");
            tested.GotoNextRow();
            tested.AddCellInRowAndGoToNextColumn("pierwsza-komorka_r2");
            try
            {
                tested.Build();
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(e.Message.Contains("rows"));
                return;
            }
            Assert.Fail();
        }
    }
}
