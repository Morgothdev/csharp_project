using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSources.Logic;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace DSources.Parsers
{
    [TestClass]
    public class TestValidatingArgumentsDuringConfiguring
    {

        public static ParserConfiguration DeepClone(ParserConfiguration obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (ParserConfiguration)formatter.Deserialize(ms);
            }
        }

        List<ParserConfiguration> prepareNotValidParserConfigurations(ParserConfiguration fullValid)
        {
            List<ParserConfiguration> result = new List<ParserConfiguration>();
            IEnumerator<KeyValuePair<string, string>> en = fullValid.getProperties().GetEnumerator();
            while (en.MoveNext())
            {
                KeyValuePair<string, string> pair = en.Current;
                //pomijamy klucze których testowanie validacji jest wykonywane dopiero podczas czytania
                if (
                    !pair.Key.Equals(DBParser.REQUEST_KEY) &&
                    !pair.Key.Equals(MongoDBParser.COLLECTION_NAME_KEY) &&
                    !pair.Key.Equals(MongoDBParser.FIELD_NAMES_KEY) &&
                    !pair.Key.Equals(XLSParser.WORK_SHEET_NAME_KEY)
                )
                {
                    result.Add(DeepClone(fullValid).ReplaceValue(pair.Key, "wrong"));
                }
            }
            return result;
        }

        void printProblems(ICollection<string> problems)
        {
            IEnumerator<string> en = problems.GetEnumerator();
            while (en.MoveNext())
            {
                Console.WriteLine(en.Current);
            }
        }

        private void Check(ParserConfiguration notValid, InternalParser tested)
        {
            tested.Init();
            //oCnsole.WriteLine("size " + notValid._properties.Count);
            tested.ConfigureItSelf(notValid);
            Assert.IsFalse(tested.IsValid);
            printProblems(tested.Problems);
        }

        [TestMethod]
        [TestCategory("CSVParser")]
        [TestCategory("Validating valid arguments")]
        public void ValidateArgumentsCSV()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty(CSVParser.FILE_PATH_KEY, "C:/tests/SampleData.csv");
            builder.SetProperty(XLSParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserConfiguration conf = builder.Build();
            Console.WriteLine("size " + conf.getProperties().Count);
            foreach (ParserConfiguration notValid in prepareNotValidParserConfigurations(conf))
            {
                Check(notValid,  new CSVParser());
            }
        }


        [TestMethod]
        [TestCategory("XLSParser")]
        [TestCategory("Validating valid arguments")]
        public void ValidateArgumentsXLS()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty(XLSParser.FILE_PATH_KEY, "C:/tests/SampleData.xls");
            builder.SetProperty(XLSParser.WORK_SHEET_NAME_KEY, "test");
            builder.SetProperty(XLSParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserConfiguration conf = builder.Build();
            //Console.WriteLine("size " + conf._properties.Count);
            foreach (ParserConfiguration notValid in prepareNotValidParserConfigurations(conf))
            {
                Check(notValid,  new XLSParser());
            }
        }

        [TestMethod]
        [TestCategory("XMLParser")]
        [TestCategory("Validating valid arguments")]
        public void ValidateArgumentsXML()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty(XMLParser.FILE_PATH_KEY, "C:/tests/SampleData2.xml");
            builder.SetProperty(XMLParser.ORDER_IN_DATA, "column by column");
            builder.SetProperty(XMLParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserConfiguration conf = builder.Build();
            foreach (ParserConfiguration notValid in prepareNotValidParserConfigurations(conf))
            {
                Check(notValid, new XMLParser());
            }
        }

        [TestMethod]
        [TestCategory("DSNParser")]
        [TestCategory("Validating valid arguments")]
        public void ValidateArgumentsDSN()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty(DSNParser.DSN_NAME_KEY, "DSB_pg");
            builder.SetProperty(DSNParser.REQUEST_KEY, "select region, rep, item, units, cost, total from sampledata");
            builder.SetProperty(DSNParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserConfiguration conf = builder.Build();
            foreach (ParserConfiguration notValid in prepareNotValidParserConfigurations(conf))
            {
                Check(notValid, new DSNParser());
            }
        }

        [TestMethod]
        [TestCategory("MSSQLParser")]
        [TestCategory("Validating valid arguments")]
        public void ValidateArgumentsMSSQL()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty(MSSQLParser.SERVER_IP_KEY, "KOMP\\SQLEXPRESS");
            builder.SetProperty(MSSQLParser.DATABASE_NAME_KEY, "dsourcesbase");
            builder.SetProperty(MSSQLParser.USER_NAME_KEY, "dsourcesclient");
            builder.SetProperty(MSSQLParser.USER_PASSWORD_KEY, "client123");
            builder.SetProperty(MSSQLParser.REQUEST_KEY, "select region, rep, item, units, cost, total from sampledata");
            builder.SetProperty(MSSQLParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserConfiguration conf = builder.Build();
            foreach (ParserConfiguration notValid in prepareNotValidParserConfigurations(conf))
            {
                Check(notValid, new MSSQLParser());
            }
        }

        [TestMethod]
        [TestCategory("PostgreSQLParser")]
        [TestCategory("Validating valid arguments")]
        public void ValidateArgumentsPostgreSQL()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty(PostgreSQLParser.SERVER_IP_KEY, "localhost");
            builder.SetProperty(PostgreSQLParser.SERVER_PORT_KEY, "5432");
            builder.SetProperty(PostgreSQLParser.DATABASE_NAME_KEY, "dsourcesbase");
            builder.SetProperty(PostgreSQLParser.USER_NAME_KEY, "dsourcesclient");
            builder.SetProperty(PostgreSQLParser.USER_PASSWORD_KEY, "dsourcesclient");
            builder.SetProperty(PostgreSQLParser.REQUEST_KEY, "select region, rep, item, units, cost, total from sampledata");
            builder.SetProperty(PostgreSQLParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserConfiguration conf = builder.Build();
            foreach (ParserConfiguration notValid in prepareNotValidParserConfigurations(conf))
            {;
                Check(notValid, new PostgreSQLParser());
            }
        }

        [TestMethod]
        [TestCategory("MySQLParser")]
        [TestCategory("Validating valid arguments")]
        public void ValidateArgumentsMySQLParser()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty(MySQLParser.SERVER_IP_KEY, "sql4.freemysqlhosting.net");
            builder.SetProperty(MySQLParser.SERVER_PORT_KEY, "3306");
            builder.SetProperty(MySQLParser.DATABASE_NAME_KEY, "sql424779");
            builder.SetProperty(MySQLParser.USER_NAME_KEY, "sql424779");
            builder.SetProperty(MySQLParser.USER_PASSWORD_KEY, "xB4%lD4%");
            builder.SetProperty(MySQLParser.REQUEST_KEY, "select region, rep, item, units, cost, total from sampledata");
            builder.SetProperty(MySQLParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserConfiguration conf = builder.Build();
            foreach (ParserConfiguration notValid in prepareNotValidParserConfigurations(conf))
            {
                Check(notValid,  new MySQLParser());
            }
        }

        [TestMethod]
        [TestCategory("MongoDBParser")]
        [TestCategory("Validating valid arguments")]
        public void ValidateArgumentsMongoDBParser()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty(MongoDBParser.SERVER_IP_KEY, "ds057568.mongolab.com");
            builder.SetProperty(MongoDBParser.SERVER_PORT_KEY, "57568");
            builder.SetProperty(MongoDBParser.DATABASE_NAME_KEY, "dsourcesbase");
            builder.SetProperty(MongoDBParser.USER_NAME_KEY, "dsourcesclient");
            builder.SetProperty(MongoDBParser.USER_PASSWORD_KEY, "dsourcesclient");
            builder.SetProperty(MongoDBParser.COLLECTION_NAME_KEY, "sampledata");
            builder.SetProperty(MongoDBParser.FIELD_NAMES_KEY, "Region, Rep, Item, Units, Cost, Total");
            builder.SetProperty(MongoDBParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserConfiguration conf = builder.Build();
            foreach (ParserConfiguration notValid in prepareNotValidParserConfigurations(conf))
            {
                Check(notValid, new MongoDBParser());
            }
        }
    }

}