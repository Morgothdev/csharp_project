using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSources.Logic;
using DSources.Parsers;
using System.Linq;

namespace DSources
{
    [TestClass]
    public class AcceptanceTests
    {
        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Implemented")]
        public void Lista__Parserow()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            Assert.IsTrue(facade.GetParsersInfoAsCollection().Count == 8);
        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Lista__argumentow__parsera")]
        [TestCategory("Implemented")]
        public void List__argumentów__parsera__CSV()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserInfo csvPI = facade.GetParsersInfoAsCollection().First(p=>p.ParserName.Equals(CSVParser.Name));
            ICollection<string> parserArguments = csvPI.GetNecessaryArgumentsAsCollection().Select<ParserArgumentInfo, string>(p => p.Name).ToList();
            Assert.IsTrue(parserArguments.Contains(CSVParser.FILE_PATH_KEY));
            Assert.IsTrue(parserArguments.Contains(CSVParser.COLUMN_OBJECT_TYPES_KEY));
            Assert.IsTrue(parserArguments.Count.Equals(2));
        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Lista__argumentow__parsera")]
        [TestCategory("Implemented")]
        public void List__argumentów__parsera__XML()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserInfo xmlPI = facade.GetParsersInfoAsCollection().First(p => p.ParserName.Equals(XMLParser.Name));
            ICollection<string> parserArguments = xmlPI.GetNecessaryArgumentsAsCollection().Select<ParserArgumentInfo, string>(p => p.Name).ToList();
            Assert.IsTrue(parserArguments.Contains(XMLParser.ORDER_IN_DATA));
            Assert.IsTrue(parserArguments.Contains(XMLParser.FILE_PATH_KEY));
            Assert.IsTrue(parserArguments.Contains(XMLParser.COLUMN_OBJECT_TYPES_KEY));
            Assert.IsTrue(parserArguments.Count.Equals(3));
        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Lista__argumentow__parsera")]
        [TestCategory("Implemented")]
        public void List__argumentów__parsera__XLS()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserInfo xlsPI = facade.GetParsersInfoAsCollection().First(p => p.ParserName.Equals(XLSParser.Name));
            ICollection<string> parserArguments = xlsPI.GetNecessaryArgumentsAsCollection().Select<ParserArgumentInfo, string>(p => p.Name).ToList();
            Assert.IsTrue(parserArguments.Contains(XLSParser.FILE_PATH_KEY));
            Assert.IsTrue(parserArguments.Contains(XLSParser.COLUMN_OBJECT_TYPES_KEY));
            Assert.IsTrue(parserArguments.Contains(XLSParser.WORK_SHEET_NAME_KEY));
            Assert.IsTrue(parserArguments.Count.Equals(3));
        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Lista__argumentow__parsera")]
        [TestCategory("Implemented")]
        public void List__argumentów__parsera__DSN()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserInfo dsnPI = facade.GetParsersInfoAsCollection().First(p => p.ParserName.Equals(DSNParser.Name));
            ICollection<string> parserArguments = dsnPI.GetNecessaryArgumentsAsCollection().Select<ParserArgumentInfo, string>(p => p.Name).ToList();
            Assert.IsTrue(parserArguments.Contains(DSNParser.REQUEST_KEY));
            Assert.IsTrue(parserArguments.Contains(DSNParser.COLUMN_OBJECT_TYPES_KEY));
            Assert.IsTrue(parserArguments.Contains(DSNParser.DSN_NAME_KEY));
            Assert.IsTrue(parserArguments.Count.Equals(3));
        }


        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Lista__argumentow__parsera")]
        [TestCategory("Implemented")]
        public void List__argumentów__parsera__MongoDB()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserInfo mongoPI = facade.GetParsersInfoAsCollection().First(p => p.ParserName.Equals(MongoDBParser.Name));
            ICollection<string> parserArguments = mongoPI.GetNecessaryArgumentsAsCollection().Select<ParserArgumentInfo, string>(p => p.Name).ToList();
            Assert.IsTrue(parserArguments.Contains(MongoDBParser.DATABASE_NAME_KEY));
            Assert.IsTrue(parserArguments.Contains(MongoDBParser.COLUMN_OBJECT_TYPES_KEY));
            Assert.IsTrue(parserArguments.Contains(MongoDBParser.COLLECTION_NAME_KEY));
            Assert.IsTrue(parserArguments.Contains(MongoDBParser.FIELD_NAMES_KEY));
            Assert.IsTrue(parserArguments.Contains(MongoDBParser.SERVER_IP_KEY));
            Assert.IsTrue(parserArguments.Contains(MongoDBParser.SERVER_PORT_KEY));
            Assert.IsTrue(parserArguments.Contains(MongoDBParser.USER_NAME_KEY));
            Assert.IsTrue(parserArguments.Contains(MongoDBParser.USER_PASSWORD_KEY));
            Assert.IsTrue(parserArguments.Count.Equals(8));
        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Lista__argumentow__parsera")]
        [TestCategory("Implemented")]
        public void List__argumentów__parsera__MSSQL()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserInfo mssqlPI = facade.GetParsersInfoAsCollection().First(p => p.ParserName.Equals(MSSQLParser.Name));
            ICollection<string> parserArguments = mssqlPI.GetNecessaryArgumentsAsCollection().Select<ParserArgumentInfo, string>(p => p.Name).ToList();
            Assert.IsTrue(parserArguments.Contains(MSSQLParser.DATABASE_NAME_KEY));
            Assert.IsTrue(parserArguments.Contains(MSSQLParser.COLUMN_OBJECT_TYPES_KEY));
            Assert.IsTrue(parserArguments.Contains(MSSQLParser.SERVER_IP_KEY));
            Assert.IsTrue(parserArguments.Contains(MSSQLParser.USER_NAME_KEY));
            Assert.IsTrue(parserArguments.Contains(MSSQLParser.USER_PASSWORD_KEY));
            Assert.IsTrue(parserArguments.Contains(MSSQLParser.REQUEST_KEY));
            Assert.IsTrue(parserArguments.Count.Equals(6));
        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Lista__argumentow__parsera")]
        [TestCategory("Implemented")]
        public void List__argumentów__parsera__MySQL()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserInfo mysqlPI = facade.GetParsersInfoAsCollection().First(p => p.ParserName.Equals(MySQLParser.Name));
            ICollection<string> parserArguments = mysqlPI.GetNecessaryArgumentsAsCollection().Select<ParserArgumentInfo, string>(p => p.Name).ToList();
            Assert.IsTrue(parserArguments.Contains(MySQLParser.DATABASE_NAME_KEY));
            Assert.IsTrue(parserArguments.Contains(MySQLParser.COLUMN_OBJECT_TYPES_KEY));
            Assert.IsTrue(parserArguments.Contains(MySQLParser.SERVER_IP_KEY));
            Assert.IsTrue(parserArguments.Contains(MySQLParser.SERVER_PORT_KEY));
            Assert.IsTrue(parserArguments.Contains(MySQLParser.USER_NAME_KEY));
            Assert.IsTrue(parserArguments.Contains(MySQLParser.USER_PASSWORD_KEY));
            Assert.IsTrue(parserArguments.Contains(MySQLParser.REQUEST_KEY));
            Assert.IsTrue(parserArguments.Count.Equals(7));
        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Lista__argumentow__parsera")]
        [TestCategory("Implemented")]
        public void List__argumentów__parsera__PostreSQL()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserInfo pgPI = facade.GetParsersInfoAsCollection().First(p => p.ParserName.Equals(PostgreSQLParser.Name));
            ICollection<string> parserArguments = pgPI.GetNecessaryArgumentsAsCollection().Select<ParserArgumentInfo, string>(p => p.Name).ToList();
            Assert.IsTrue(parserArguments.Contains(PostgreSQLParser.DATABASE_NAME_KEY));
            Assert.IsTrue(parserArguments.Contains(PostgreSQLParser.COLUMN_OBJECT_TYPES_KEY));
            Assert.IsTrue(parserArguments.Contains(PostgreSQLParser.SERVER_IP_KEY));
            Assert.IsTrue(parserArguments.Contains(PostgreSQLParser.SERVER_PORT_KEY));
            Assert.IsTrue(parserArguments.Contains(PostgreSQLParser.USER_NAME_KEY));
            Assert.IsTrue(parserArguments.Contains(PostgreSQLParser.USER_PASSWORD_KEY));
            Assert.IsTrue(parserArguments.Contains(PostgreSQLParser.REQUEST_KEY));
            Assert.IsTrue(parserArguments.Count.Equals(7));
        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Implemented")]
        public void CSVParserGet()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetParserName("CSV File");
            builder.SetProperty(CSVParser.FILE_PATH_KEY, "C:/tests/test.csv");
            builder.SetProperty(CSVParser.COLUMN_OBJECT_TYPES_KEY, "Dimension,IntegerFact");
            ParserBridge returned = (ParserBridge)facade.GetParser(builder.Build());
            Assert.IsTrue(((AbstractParser)returned.parser).IsTheSameAs(new CSVParser()));
        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Implemented")]
        public void XMLParserGetViaValidArguments()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetParserName("XML File");
            builder.SetProperty(CSVParser.FILE_PATH_KEY, "C:/tests/SampleData.xml");
            builder.SetProperty(CSVParser.ORDER_IN_DATA, "row by row");
            builder.SetProperty(CSVParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserBridge returned = (ParserBridge)facade.GetParser(builder.Build());
            Assert.IsTrue(((AbstractParser)returned.parser).IsTheSameAs(new XMLParser()));
            Assert.IsTrue(returned.parser.IsValid);

        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Implemented")]
        public void XMLParserGetViaInValidArguments()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetParserName("XML File");
            builder.SetProperty(CSVParser.FILE_PATH_KEY, "C:/tests/testa.xml");
            builder.SetProperty(CSVParser.COLUMN_OBJECT_TYPES_KEY, "Dimension,IntegerFact");
            ParserBridge returned = (ParserBridge)facade.GetParser(builder.Build());
            Assert.IsTrue(((AbstractParser)returned.parser).IsTheSameAs(new XMLParser()));
            Assert.IsFalse(returned.parser.IsValid);
        }

    }
}
