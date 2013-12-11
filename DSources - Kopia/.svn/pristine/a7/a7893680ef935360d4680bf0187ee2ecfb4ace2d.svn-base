using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;
using DSources.Logic;
using System.Resources;
using System.Reflection;

namespace DSources.Parsers
{
    [TestClass]
    public class CSVFileParserTest
    {
        Mockery mockery;
        CSVParser tested;
        ParserConfiguration configuration;


        [TestInitialize]
        public void SetUp()
        {
            mockery = new Mockery();
            tested = new CSVParser();
        }


        
        [TestMethod]
        [TestCategory("ParserInfo")]
        [TestCategory("Not implemented")]
        public void ReadingTestData()
        {
            tested.FilePath = "./test.csv";
            tested.ParseData();
            Console.Write(tested.ParserCore.ToString());
        }
    }
}
