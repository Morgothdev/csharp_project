using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NMock2;
using DSources.Parsers;

namespace DSources.Logic
{
    [TestClass]
    public class ParsersLoaderTest
    {
        [TestMethod]
        [TestCategory("ParsersLoader")]
        [TestCategory("Implemented")]
        public void TestLoadInvalidParser()
        {
            Mockery mockery = new Mockery();

            InternalParser parserMock = (InternalParser)mockery.NewMock(typeof(InternalParser));
            Expect.AtLeast(1).On(parserMock).GetProperty("IsFinal").Will(Return.Value(false));

            MyConstructor mockedConstructor = (MyConstructor)mockery.NewMock(typeof(MyConstructor));
            Expect.AtLeast(1).On(mockedConstructor).Method("Invoke").WithAnyArguments().Will(Return.Value(parserMock));

            MyType typeMock = (MyType)mockery.NewMock(typeof(MyType));
            Expect.AtLeastOnce.On(typeMock).GetProperty("DefaultConstructor").Will(Return.Value(mockedConstructor));

            ICollection<MyType> typeCollection = new LinkedList<MyType>();
            typeCollection.Add(typeMock);

            ParsersLoader testedLoader = new ParsersLoader();

            ICollection<InternalParser> loadedParsers = testedLoader.LoadParsers(typeCollection);

            Assert.IsTrue(loadedParsers.Count == 0);

            mockery.VerifyAllExpectationsHaveBeenMet();
        }


        [TestMethod]
        [TestCategory("ParsersLoader")]
        [TestCategory("Implemented")]
        public void TestLoadValidParser()
        {
            Mockery mockery = new Mockery();

            InternalParser parserMock = (InternalParser)mockery.NewMock(typeof(InternalParser));
            Expect.AtLeast(1).On(parserMock).GetProperty("IsFinal").Will(Return.Value(true));
            Expect.AtLeast(1).On(parserMock).Method("Init");


            MyConstructor constructorMock = (MyConstructor)mockery.NewMock(typeof(MyConstructor));
            Expect.AtLeast(1).On(constructorMock).Method("Invoke").WithAnyArguments().Will(Return.Value(parserMock));

            MyType typeMock = (MyType)mockery.NewMock(typeof(MyType));
            Expect.AtLeast(1).On(typeMock).GetProperty("DefaultConstructor").Will(Return.Value(constructorMock));

            ICollection<MyType> typeCollection = new LinkedList<MyType>();
            typeCollection.Add(typeMock);

            ParsersLoader testedLoader = new ParsersLoader();

            ICollection<InternalParser> loadedParsers = testedLoader.LoadParsers(typeCollection);

            Assert.IsTrue(loadedParsers.Count==1);
            Assert.IsTrue(loadedParsers.Contains(parserMock));

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        [TestCategory("ParsersLoader")]
        [TestCategory("Implemented")]
        public void TestLoadValidMoreParsers()
        {
            Mockery mockery = new Mockery();
            ParsersLoader testedLoader = new ParsersLoader();

            InternalParser parserMock = (InternalParser)mockery.NewMock(typeof(InternalParser));
            Expect.AtLeast(1).On(parserMock).GetProperty("IsFinal").Will(Return.Value(true));
            Expect.AtLeast(1).On(parserMock).Method("Init");

            MyConstructor constructorMock = (MyConstructor)mockery.NewMock(typeof(MyConstructor));
            Expect.AtLeast(1).On(constructorMock).Method("Invoke").WithAnyArguments().Will(Return.Value(parserMock));

            MyType typeMock = (MyType)mockery.NewMock(typeof(MyType));

            Expect.AtLeast(1).On(typeMock).GetProperty("DefaultConstructor").Will(Return.Value(constructorMock));


            ICollection<MyType> typeCollection = new LinkedList<MyType>();
            typeCollection.Add(typeMock);

            ICollection<InternalParser> loadedParsers = testedLoader.LoadParsers(typeCollection);

            Assert.IsTrue(loadedParsers.Count == 1);
            Assert.IsTrue(loadedParsers.Contains(parserMock));
            mockery.VerifyAllExpectationsHaveBeenMet();


            InternalParser parserMock2 = (InternalParser)mockery.NewMock(typeof(InternalParser));
            Expect.AtLeast(1).On(parserMock2).GetProperty("IsFinal").Will(Return.Value(true));
            Expect.AtLeast(1).On(parserMock2).Method("Init");

            MyConstructor constructorMock2 = (MyConstructor)mockery.NewMock(typeof(MyConstructor));
            Expect.AtLeast(1).On(constructorMock2).Method("Invoke").WithAnyArguments().Will(Return.Value(parserMock2));

            MyType typeMock2 = (MyType)mockery.NewMock(typeof(MyType));

            Expect.AtLeast(1).On(typeMock2).GetProperty("DefaultConstructor").Will(Return.Value(constructorMock2));

            typeCollection.Add(typeMock2);

            loadedParsers = testedLoader.LoadParsers(typeCollection);

            Assert.IsTrue(loadedParsers.Count == 2);
            Assert.IsTrue(loadedParsers.Contains(parserMock));
            Assert.IsTrue(loadedParsers.Contains(parserMock2));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        [TestCategory("ParsersLoader")]
        [TestCategory("Implemented")]
        public void TestLoadMoreValidParsersWithOneInvalid()
        {
            Mockery mockery = new Mockery();
            ParsersLoader testedLoader = new ParsersLoader();

            InternalParser parserMock = (InternalParser)mockery.NewMock(typeof(InternalParser));
            Expect.AtLeast(1).On(parserMock).GetProperty("IsFinal").Will(Return.Value(true));
            Expect.AtLeast(1).On(parserMock).Method("Init");

            MyConstructor constructorMock = (MyConstructor)mockery.NewMock(typeof(MyConstructor));
            Expect.AtLeast(1).On(constructorMock).Method("Invoke").WithAnyArguments().Will(Return.Value(parserMock));

            MyType typeMock = (MyType)mockery.NewMock(typeof(MyType));
            Expect.AtLeast(1).On(typeMock).GetProperty("DefaultConstructor").Will(Return.Value(constructorMock));


            InternalParser parserMock2 = (InternalParser)mockery.NewMock(typeof(InternalParser));
            Expect.AtLeast(1).On(parserMock2).GetProperty("IsFinal").Will(Return.Value(true));
            Expect.AtLeast(1).On(parserMock2).Method("Init");

            MyConstructor constructorMock2 = (MyConstructor)mockery.NewMock(typeof(MyConstructor));
            Expect.AtLeast(1).On(constructorMock2).Method("Invoke").WithAnyArguments().Will(Return.Value(parserMock2));

            MyType typeMock2 = (MyType)mockery.NewMock(typeof(MyType));
            Expect.AtLeast(1).On(typeMock2).GetProperty("DefaultConstructor").Will(Return.Value(constructorMock2));

            InternalParser invalidParserMock = (InternalParser)mockery.NewMock(typeof(InternalParser));
            Expect.AtLeast(1).On(invalidParserMock).GetProperty("IsFinal").Will(Return.Value(false));

            MyConstructor invalidParserConstructor = (MyConstructor)mockery.NewMock(typeof(MyConstructor));
            Expect.AtLeast(1).On(invalidParserConstructor).Method("Invoke").WithAnyArguments().Will(Return.Value(invalidParserMock));

            MyType invalidMock = (MyType)mockery.NewMock(typeof(MyType));
            Expect.Once.On(invalidMock).GetProperty("DefaultConstructor").Will(Return.Value(invalidParserConstructor));

            ICollection<MyType> typeCollection = new LinkedList<MyType>();
            typeCollection.Add(typeMock);
            typeCollection.Add(typeMock2);
            typeCollection.Add(invalidMock);

            ICollection<InternalParser> loadedParsers = testedLoader.LoadParsers(typeCollection);

            Assert.IsTrue(loadedParsers.Count == 2);
            Assert.IsTrue(loadedParsers.Contains(parserMock));
            Assert.IsTrue(loadedParsers.Contains(parserMock2));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
