﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSources.Logic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;


namespace DSources.Parsers
{
    [TestClass]
    public class TestValidatingArguments
    {

        public static ParserConfiguration DeepClone(ParserConfiguration obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                ParserConfiguration toReturn = (ParserConfiguration)formatter.Deserialize(ms);
                Console.WriteLine("\\\\\\"+toReturn+"\\\\\\");

                string[] items = toReturn.getProperties().Select<KeyValuePair<string, string>, string>(k => String.Join("=", k.Key, k.Value)).ToArray();
                Console.WriteLine("used configurations:\n" + String.Join("&", items));



                Console.WriteLine("\\\\\\" + toReturn + "\\\\\\");
                return toReturn;

            }
        }

        public static ParserConfiguration DeepClone2(ParserConfiguration obj)
        {
            using (var ms = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ParserConfiguration));

                serializer.Serialize(ms, obj);

                Console.WriteLine(ms.ToString());

                ParserConfiguration toReturn = (ParserConfiguration)serializer.Deserialize(new StringReader(ms.ToString()));

                //string[] items = toReturn.getProperties().Select<KeyValuePair<string, string>, string>(k => String.Join("=", k.Key, k.Value)).ToArray();
                //Console.WriteLine("\\\\\\" + "used configurations:\n" + String.Join("&", items) + "\\\\\\");

                return toReturn;

            }
        }


        List<ParserConfiguration> prepareParserConfigurationsWithMissingArgument(ParserConfiguration fullValid)
        {
            List<ParserConfiguration> result = new List<ParserConfiguration>();
            IEnumerator<KeyValuePair<string,string>> en = fullValid.getProperties().GetEnumerator();
            while (en.MoveNext())
            {
                KeyValuePair<string, string> pair = en.Current;
                if (!pair.Key.Equals("name"))
                {
                    result.Add(DeepClone2(fullValid).remove(pair.Key));
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

        [TestMethod]
        [TestCategory("CSVParser")]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Validating presence of arguments")]
        public void MissingArgumentsCSV()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty(CSVParser.FILE_PATH_KEY, "C:/tests/SampleData.csv");
            builder.SetProperty(CSVParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserConfiguration conf = builder.Build();
            Console.WriteLine("size " + conf.getProperties().Count);
            foreach (ParserConfiguration notValid in prepareParserConfigurationsWithMissingArgument(conf))
            {
                CSVParser tested = new CSVParser();
                tested.Init();
                Console.WriteLine("size " + notValid.getProperties().Count);
                tested.ConfigureItSelf(notValid);
                Assert.IsFalse(tested.IsValid);
                printProblems(tested.Problems);
            }
        }


        [TestMethod]
        [TestCategory("XLSParser")]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Validating presence of arguments")]
        public void MissingArgumentsXLS()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty(XLSParser.FILE_PATH_KEY, "C:/tests/SampleData.xls");
            builder.SetProperty(XLSParser.WORK_SHEET_NAME_KEY, "test");
            builder.SetProperty(XLSParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserConfiguration conf = builder.Build();
            //Console.WriteLine("size " + conf._properties.Count);
            foreach (ParserConfiguration notValid in prepareParserConfigurationsWithMissingArgument(conf))
            {
                XLSParser tested = new XLSParser();
                tested.Init();
                //oCnsole.WriteLine("size " + notValid._properties.Count);
                tested.ConfigureItSelf(notValid);
                Assert.IsFalse(tested.IsValid);
                printProblems(tested.Problems);
            }
        }
        
        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("XMLParser")]
        [TestCategory("Validating presence of arguments")]
        public void MissingArgumentsXML()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty(XMLParser.FILE_PATH_KEY, "C:/tests/SampleData2.xml");
            builder.SetProperty(XMLParser.ORDER_IN_DATA, "column by column");
            builder.SetProperty(XMLParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserConfiguration conf = builder.Build();
            foreach (ParserConfiguration notValid in prepareParserConfigurationsWithMissingArgument(conf))
            {
                XMLParser tested = new XMLParser();
                tested.Init();
                //oCnsole.WriteLine("size " + notValid._properties.Count);
                tested.ConfigureItSelf(notValid);
                Assert.IsFalse(tested.IsValid);
                printProblems(tested.Problems);
            }
        }

        [TestMethod]
        [TestCategory("MSSQLParser")]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Validating presence of arguments")]
        public void MissingArgumentsMSSQL()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty(MSSQLParser.SERVER_IP_KEY, "KOMP\\SQLEXPRESS");
            builder.SetProperty(MSSQLParser.DATABASE_NAME_KEY, "dsourcesbase");
            builder.SetProperty(MSSQLParser.USER_NAME_KEY, "dsourcesclient");
            builder.SetProperty(MSSQLParser.USER_PASSWORD_KEY, "client123");
            builder.SetProperty(MSSQLParser.REQUEST_KEY, "select region, rep, item, units, cost, total from sampledata");
            builder.SetProperty(MSSQLParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserConfiguration conf = builder.Build();
            foreach (ParserConfiguration notValid in prepareParserConfigurationsWithMissingArgument(conf))
            {
                MSSQLParser tested = new MSSQLParser();
                tested.Init();
                //oCnsole.WriteLine("size " + notValid._properties.Count);
                tested.ConfigureItSelf(notValid);
                Assert.IsFalse(tested.IsValid);
                printProblems(tested.Problems);
            }
        }

        [TestMethod]
        [TestCategory("DSNParser")]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Validating presence of arguments")]
        public void MissingArgumentsDSN()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty(DSNParser.DSN_NAME_KEY, "DSB_pg");
            builder.SetProperty(DSNParser.REQUEST_KEY, "select region, rep, item, units, cost, total from sampledata");
            builder.SetProperty(DSNParser.COLUMN_OBJECT_TYPES_KEY, "StringDimension,StringDimension,StringDimension, IntegerFact,FloatFact, FloatFact");
            ParserConfiguration conf = builder.Build();
            foreach (ParserConfiguration notValid in prepareParserConfigurationsWithMissingArgument(conf))
            {
                DSNParser tested = new DSNParser();
                tested.Init();
                //oCnsole.WriteLine("size " + notValid._properties.Count);
                tested.ConfigureItSelf(notValid);
                Assert.IsFalse(tested.IsValid);
                printProblems(tested.Problems);
            }
        }

        [TestMethod]
        [TestCategory("PostgreSQLParser")]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Validating presence of arguments")]
        public void MissingArgumentPostgreSQL()
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
            foreach (ParserConfiguration notValid in prepareParserConfigurationsWithMissingArgument(conf))
            {
                PostgreSQLParser tested = new PostgreSQLParser();
                tested.Init();
                //oCnsole.WriteLine("size " + notValid._properties.Count);
                tested.ConfigureItSelf(notValid);
                Assert.IsFalse(tested.IsValid);
                printProblems(tested.Problems);
            }
        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("MySQLParser")]
        [TestCategory("Validating presence of arguments")]
        public void MissingArgumentsMySQLParser()
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
            foreach (ParserConfiguration notValid in prepareParserConfigurationsWithMissingArgument(conf))
            {
                MySQLParser tested = new MySQLParser();
                tested.Init();
                //oCnsole.WriteLine("size " + notValid._properties.Count);
                tested.ConfigureItSelf(notValid);
                Assert.IsFalse(tested.IsValid);
                printProblems(tested.Problems);
            }
        }

        [TestMethod]
        [TestCategory("MongoDBParser")]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Validating presence of arguments")]
        public void MissingArgumentsMongoDBParser()
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
            foreach (ParserConfiguration notValid in prepareParserConfigurationsWithMissingArgument(conf))
            {
                MongoDBParser tested = new MongoDBParser();
                tested.Init();
                //oCnsole.WriteLine("size " + notValid._properties.Count);
                tested.ConfigureItSelf(notValid);
                Assert.IsFalse(tested.IsValid);
                printProblems(tested.Problems);
            }
        }
    }

}
