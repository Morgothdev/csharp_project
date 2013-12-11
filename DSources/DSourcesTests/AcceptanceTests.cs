﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSources.Logic;
using DSources.Parsers;

namespace DSources
{
    [TestClass]
    public class AcceptanceTests
    {
        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Not implemented")]
        public void ParsersCount()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            Assert.IsTrue(facade.GetParsersInfoAsCollection().Count == 3);
        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Not implemented")]
        public void CSVParserGet()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetParserName("CSV File Parser");
            builder.SetProperty(CSVParser.FILE_PATH_KEY, "./test.csv");
            builder.SetProperty(CSVParser.COLUMN_OBJECT_TYPES_KEY, "Dimension,IntegerFact");
            ParserBridge returned = (ParserBridge)facade.GetParser(builder.Build());
            Assert.IsTrue(((AbstractParser)returned.parser).IsTheSameAs(new CSVParser()));
            
        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Not implemented")]
        public void XMLParserGetViaValidArguments()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetParserName("XML File Parser");
            builder.SetProperty(CSVParser.FILE_PATH_KEY, "./test.xml");
            builder.SetProperty(CSVParser.COLUMN_OBJECT_TYPES_KEY, "Dimension,IntegerFact");
            ParserBridge returned = (ParserBridge)facade.GetParser(builder.Build());
            Assert.IsTrue(((AbstractParser)returned.parser).IsTheSameAs(new XMLParser()));
            Assert.IsTrue(returned.parser.IsValid);

        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Not implemented")]
        public void XMLParserGetViaInValidArguments()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetParserName("XML File Parser");
            builder.SetProperty(CSVParser.FILE_PATH_KEY, "./testa.xml");
            builder.SetProperty(CSVParser.COLUMN_OBJECT_TYPES_KEY, "Dimension,IntegerFact");
            ParserBridge returned = (ParserBridge)facade.GetParser(builder.Build());
            Assert.IsTrue(((AbstractParser)returned.parser).IsTheSameAs(new XMLParser()));
            Assert.IsFalse(returned.parser.IsValid);
        }

    }
}
