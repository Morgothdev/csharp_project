using System;
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
        [TestCategory("Implemented")]
        public void Lista__Parserow()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            Assert.IsTrue(facade.GetParsersInfoAsCollection().Count == 7);
        }

        [TestMethod]
        [TestCategory("ACCEPTANCE")]
        [TestCategory("Not implemented")]
        public void List__argumentów__parsera__CSV()
        {
            DSourcesFacade facade = DSourcesFacade.Instance;
            
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
