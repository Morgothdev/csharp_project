using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM;


namespace DSources.Parsers
{
    /**
     * Niefunkcjonalny czytnik. Zawierający bazową funkcjonalność oraz metody szablonowe.
     */
    internal class AbstractParser : InternalParser
    {
        public static String COLUMN_OBJECT_TYPES_KEY = "Object type in columns";

        private ParserInfo _arguments = new ParserInfo();

        internal ParserCore ParserCore { get; set; }

        internal override ParserInfo Arguments { get { return _arguments; } set { throw new NotSupportedException(); } }

        internal override bool IsFinal { get { return false; } }

        public AbstractParser()
        {
            ParserCore = new ParserCore();
        }

        internal override InternalParser ClonePrototype()
        {
            throw new NotSupportedException();
        }


        protected DataType[] objectTypes;

        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            Console.WriteLine(String.Join(", ", configuration._properties.Keys));
            Console.WriteLine(String.Join(" || ", configuration._properties.Values));

            if (Arguments.ContainsArgument(COLUMN_OBJECT_TYPES_KEY))
            {
                if (R.DEBUG) Console.WriteLine(configuration.GetProperty(COLUMN_OBJECT_TYPES_KEY));

                string objectTypesNamesString = configuration.GetProperty(COLUMN_OBJECT_TYPES_KEY);

                if (objectTypesNamesString == null)
                {
                    problems.Add("Absent argument: " + COLUMN_OBJECT_TYPES_KEY);
                    if (R.DEBUG) Console.WriteLine("Absent argument: " + COLUMN_OBJECT_TYPES_KEY);
                }
                else
                {
                    string[] objectTypesNames = objectTypesNamesString.ToLower().Split(',').Select(p => p.Trim()).ToArray();
                    //objectTypesNames.Select(p=> p
                    objectTypes = new DataType[objectTypesNames.Count()];
                    
                    try
                    {
                        String objectTypeName;
                        for (int i = 0; i < objectTypesNames.Count(); ++i)
                        {
                            objectTypeName = objectTypesNames[i];
                            //rzuca wyjatkiem, jak jest podany zły argument
                            objectTypes[i] = (DataType)Enum.Parse(typeof(DataType), objectTypeName, true);
                        }
                    }
                    catch (ArgumentNullException)
                    {
                        problems.Add("one of object types is unrecognized");
                        if (R.DEBUG) Console.WriteLine("one of object types is unrecognized");
                    }
                    catch (ArgumentException)
                    {
                        problems.Add("one of object types is unrecognized");
                        if (R.DEBUG) Console.WriteLine("one of object types is unrecognized");
                    }
                    catch (OverflowException)
                    {
                        problems.Add("one of object types is unrecognized");
                        if (R.DEBUG) Console.WriteLine("one of object types is unrecognized");
                    }
                }
            }


            //Console.WriteLine("abstract configured: " + roles + "|" + objectTypes);
        }

        internal override void Init()
        {
            ParserArgumentInfo column_object_types = new ParserArgumentInfo(COLUMN_OBJECT_TYPES_KEY, ArgType.ColumnTypes, "List of object types in columns, in format: \"<object_type> , <object_type> , (...)\" where <object_type> is one of: DateDimension, StringDimension, IntegerFact, FloatFact", string.Join(",", Enum.GetNames(typeof(DataType))));
            Arguments.AddArgument(column_object_types);
        }

        internal override Table Parse()
        {
            if (IsValid == false) { throw new Exception("Not Valid Parser!"); }
            ParseData();
            return ParserCore.Build();
        }

        internal void ParseData()
        {
            InitParserCore();

            Read();
        }

        internal virtual void Read() { throw new NotSupportedException(); }

        private void InitParserCore()
        {
            ParserCore.Init();

            InsertColumnTypesAndRolesIntoParserCore();

            ParserCore.GotoStart();
        }

        private void InsertColumnTypesAndRolesIntoParserCore()
        {
            for (int i = 0; i < objectTypes.Length; ++i)
            {
                ParserCore.SetColumnType(objectTypes[i]);
                ParserCore.GotoNextColumn();
            }
        }



        internal virtual string parserName { get { return "Asbtract"; } }

        internal bool IsTheSameAs(AbstractParser another)
        {
            return another.parserName.Equals(parserName);
        }

        internal virtual List<string> SplitSecondNest(string firstNest)
        {
            throw new NotImplementedException();
        }

        internal virtual string ReadData()
        {
            throw new NotImplementedException();
        }

        internal virtual List<string> SplitFirstNest(string Data)
        {
            throw new NotImplementedException();
        }
    }
}
