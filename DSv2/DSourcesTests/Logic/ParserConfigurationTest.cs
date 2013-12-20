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

        [TestMethod]
        [TestCategory("ParserConfiguration")]
        [TestCategory("Implemented")]
        public void TestSettingTwiceShouldNotThrowException()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty("test", "testValue");
            try
            {
                builder.SetProperty("test", "anotherValue");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [TestCategory("ParserConfiguration")]
        [TestCategory("Implemented")]
        public void TestSettingTwiceShouldSettedSecondValue()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty("test", "testValue");
            builder.SetProperty("test", "anotherValue");
            Assert.AreEqual(builder.Build().GetProperty("test"), "anotherValue");
        }

        [TestMethod]
        [TestCategory("ParserConfiguration")]
        [TestCategory("Implemented")]
        public void TestRemovingProperties()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty("test", "testValue");
            builder.SetProperty("test2", "anotherValue");
            ParserConfiguration conf = builder.Build();
            conf.remove("test");
            Assert.IsNull(conf.GetProperty("test"));
            Assert.AreEqual(conf.GetProperty("test2"), "anotherValue");
        }

        [TestMethod]
        [TestCategory("ParserConfiguration")]
        [TestCategory("Implemented")]
        public void TestReplacingProperties()
        {
            ParserConfiguration.Builder builder = ParserConfiguration.GetBuilder();
            builder.SetProperty("test", "testValue");
            ParserConfiguration conf = builder.Build();
            conf.ReplaceValue("test", "newValue");
            Assert.AreEqual(conf.GetProperty("test"), "newValue");
        }
    }
}
