﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;
using DSources.Logic;
using System.Resources;
using System.Reflection;
using UDM;

namespace DSources.Parsers
{
    [TestClass]
    public class ParsersTests
    {
        [TestMethod]
        [TestCategory("CSVParser")]
        [TestCategory("TESTING_BY_HAND")]
        public void CSVReadingTestData()
        {
            CSVParser tested = new CSVParser();
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            tested.Init();
            builder.SetParserName("CSV File Parser");
            builder.SetProperty(CSVParser.FILE_PATH_KEY, "./test.csv");
            builder.SetProperty(CSVParser.COLUMN_OBJECT_TYPES_KEY, "Dimension,IntegerFact");
            tested.ConfigureItSelf(builder.Build());
            tested.ParseData();
            Console.Write(tested.ParserCore.ToString());
            Table t = tested.ParserCore.Build();
            Assert.IsNotNull(t);
            WriteTable(t);
        }

        private static void WriteTable(Table t)
        {
            foreach (Column col in t.Columns)
            {
                Console.WriteLine("Column:");
                Console.WriteLine("\tname: " + col.Name);
                Console.Write("\tcells: ");
                foreach (Cell c in col.Cells)
                {
                    Console.Write("\"" + c.Content + "\" ");
                }
                Console.WriteLine();
            }
        }

        [TestMethod]
        [TestCategory("XMLParser")]
        [TestCategory("TESTING_BY_HAND")]
        public void XMLReadingTestDataFirstRows()
        {
            XMLParser tested = new XMLParser();
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            tested.Init();
            builder.SetParserName("XML File Parser");
            builder.SetProperty(XMLParser.FILE_PATH_KEY, "./test.xml");
            builder.SetProperty(XMLParser.ORDER_IN_DATA, "row by row");
            builder.SetProperty(XMLParser.COLUMN_OBJECT_TYPES_KEY, "Dimension,IntegerFact");
            tested.ConfigureItSelf(builder.Build());
            tested.ParseData();
            Console.Write(tested.ParserCore.ToString());

            Table t = tested.ParserCore.Build();

            WriteTable(t);
        }

        [TestMethod]
        [TestCategory("XMLParser")]
        [TestCategory("TESTING_BY_HAND")]
        public void XMLReadingTestDataFirstColumns()
        {
            XMLParser tested = new XMLParser();
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            tested.Init();
            builder.SetParserName("XML File Parser");
            builder.SetProperty(XMLParser.FILE_PATH_KEY, "./test2.xml");
            builder.SetProperty(XMLParser.ORDER_IN_DATA, "column by column");
            builder.SetProperty(XMLParser.COLUMN_OBJECT_TYPES_KEY, "Dimension,IntegerFact");
            tested.ConfigureItSelf(builder.Build());
            tested.ParseData();
            Console.Write(tested.ParserCore.ToString());

            Table t = tested.ParserCore.Build();

            WriteTable(t);
        }
    }
}
