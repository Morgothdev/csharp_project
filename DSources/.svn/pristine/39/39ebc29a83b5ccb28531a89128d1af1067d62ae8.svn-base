using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;
using System.Collections.Generic;
using DSources.Logic;

namespace DSourcesLogic
{
    [TestClass]
    public class ParserConfigurationTest
    {

        [TestMethod]
        [TestCategory("ParserConfiguration")]
        [TestCategory("Implemented")]
        public void TestGetBuilder()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            Assert.IsNotNull(builder);
        }

        [TestMethod]
        [TestCategory("ParserConfiguration")]
        [TestCategory("Implemented")]
        public void TestSettingParams()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            String testingKey = "testowyKlucz";
            String testingValue  = "testowaWartość";
            builder.SetProperty(testingKey,testingValue);
            Assert.AreEqual(builder.Build().GetProperty(testingKey), testingValue);
        }

        [TestMethod]
        [TestCategory("ParserConfiguration")]
        [TestCategory("Implemented")]
        public void TestSerializable()
        {
            Boolean isSerializable = Attribute.IsDefined(typeof(ParserConfiguration), typeof(SerializableAttribute));
            Assert.IsTrue(isSerializable);
        }

        [TestMethod]
        [TestCategory("ParserConfiguration")]
        [TestCategory("Implemented")]
        public void TestSettingName()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            String testingName = "testowaWartość";
            builder.SetParserName(testingName);
            Assert.AreEqual(builder.Build().GetParserName(), testingName);
        }

        [TestMethod]
        [TestCategory("ParserConfiguration")]
        [TestCategory("Implemented")]
        public void TestSettingNameAlsoArgument()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            String testingName = "testowaWartość";
            builder.SetParserName(testingName);
            String testingKey = "testowyKlucz";
            String testingValue = "testowaWartość";
            builder.SetProperty(testingKey, testingValue);
            Assert.AreEqual(builder.Build().GetParserName(), testingName);
            Assert.AreEqual(builder.Build().GetProperty(testingKey), testingValue);
        }

        [TestMethod]
        [TestCategory("ParserConfiguration")]
        [TestCategory("Implemented")]
        public void TestNullReferenceExceptionIfSettingNullAsName()
        {
            try
            {
                ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
                builder.SetParserName(null);
            }
            catch (NullReferenceException)
            {
                Assert.IsTrue(true);
                return;
            };
            Assert.Fail("NullReferenceExceptionNotThrowed");
        }

        [TestMethod]
        [TestCategory("ParserConfiguration")]
        [TestCategory("Implemented")]
        public void TestNullReferenceExceptionIfSettingNullAsPropertyKey()
        {
            try
            {
                ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
                builder.SetProperty(null,"someValue");
            }
            catch (NullReferenceException)
            {
                Assert.IsTrue(true);
                return;
            };
            Assert.Fail("NullReferenceExceptionNotThrowed");
        }

        [TestMethod]
        [TestCategory("ParserConfiguration")]
        [TestCategory("Implemented")]
        public void TestNullReferenceExceptionIfSettingNullAsPropertyValue()
        {
            try
            {
                ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
                builder.SetProperty("someKey",null);
            }
            catch (NullReferenceException)
            {
                Assert.IsTrue(true);
                return;
            };
            Assert.Fail("NullReferenceExceptionNotThrowed");
        }
    }
}
