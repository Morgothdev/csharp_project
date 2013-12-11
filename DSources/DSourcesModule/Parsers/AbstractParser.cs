﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM;


namespace DSources.Parsers
{
    internal class AbstractParser : InternalParser
    {
        public static String COLUMN_OBJECT_TYPES_KEY = "Object type in columns";
        public static string ORDER_IN_DATA = "Order in data";

        protected ISet<String> problems = new HashSet<String>();
        
        private ParserInfo _arguments = new ParserInfo();

        internal ParserCore ParserCore { get; set; }

        internal override ParserInfo Arguments { get { return _arguments; } set { throw new NotSupportedException(); } }

        internal override  bool IsFinal { get { return false; } }

        internal override  bool IsValid { get { return false; } }

        public AbstractParser()
        {
            ParserCore = new ParserCore();
        }

        internal override InternalParser ClonePrototype()
        {
            throw new NotImplementedException();
        }


        protected DataType[] objectTypes;
        
        internal bool RowsInFirstNest{get; set;}

        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            if (Arguments.ContainsArgument(COLUMN_OBJECT_TYPES_KEY))
            {
//                Console.WriteLine(configuration.GetProperty(COLUMN_OBJECT_TYPES_KEY).ToLower());
                string objectTypesNamesString = configuration.GetProperty(COLUMN_OBJECT_TYPES_KEY);

                if (objectTypesNamesString == null)
                {
                    problems.Add("Absent argument: " + COLUMN_OBJECT_TYPES_KEY);
                    return;
                }

                string[] objectTypesNames = objectTypesNamesString.ToLower().Split(',');
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
                    return;
                }
                catch (ArgumentException)
                {
                    problems.Add("one of object types is unrecognized");
                    return;
                }
                catch (OverflowException)
                {
                    problems.Add("one of object types is unrecognized");
                    return;
                }
            }

            if (Arguments.ContainsArgument(ORDER_IN_DATA))
            {
                //                Console.WriteLine(configuration.GetProperty(ORDER_IN_DATA).ToLower());
                string order = configuration.GetProperty(ORDER_IN_DATA);

                if (order == null)
                {
                    problems.Add("Absent argument: " + ORDER_IN_DATA);
                    return;
                }

                order = order.ToLower();

                if (!order.Equals("row by row") && !order.Equals("column by column"))
                {
                    problems.Add("Unrecognized order: " + order);
                    return;
                }
                RowsInFirstNest = order.Equals("row by row");
            }
            else
            {
                RowsInFirstNest = true;
            }

//            Console.WriteLine("abstract configured: " + roles + "|" + objectTypes);
        }

        internal override void Init()
        {
            ParserArgumentInfo column_object_types = new ParserArgumentInfo(COLUMN_OBJECT_TYPES_KEY, ArgType.Text, "List of object types in columns, in format: \"<object_type> , <object_type> , (...)\" where <object_type> is one of: Text, Integer, Floating, Date", string.Join(",", Enum.GetNames(typeof(DataType))));
            ParserArgumentInfo order_in_data = new ParserArgumentInfo(ORDER_IN_DATA, ArgType.Enum, "Order in the data whether or column by column or row by row", "row by row,column by column");

            Arguments.AddArgument(column_object_types);
            Arguments.AddArgument(order_in_data);
        }




        internal override Table Parse()
        {
            ParseData();
            return ParserCore.Build();
        }

        internal void ParseData()
        {
            Console.WriteLine("rows in forst nest: " + RowsInFirstNest);

            ParserCore.Init();

            InsertColumnTypesAndRolesIntoParserCore();
            
            ParserCore.GotoStart();

            string data = ReadData();
            
            List<string> lines = SplitFirstNest(data);
            
            if (RowsInFirstNest)
            {
                parseFirstNestAsRows(lines);
            }
            else
            {
                parseFirstNestAsColumns(lines);
            }
        }

        private void InsertColumnTypesAndRolesIntoParserCore()
        {
            for (int i = 0; i < objectTypes.Length; ++i)
            {
                ParserCore.SetColumnType(objectTypes[i]);
                ParserCore.GotoNextColumn();

            }
        }

        internal virtual string ReadData()
        {
            throw new NotImplementedException();
        }

        internal virtual List<string> SplitFirstNest(string Data)
        {
            throw new NotImplementedException();
        }

        internal void parseFirstNestAsRows(List<string> lines)
        {
            foreach (String columnName in SplitSecondNest(lines.ElementAt(0)))
            {
                ParserCore.SetColumnName(columnName);
                ParserCore.GotoNextColumn();
            }
            ParserCore.GotoStart();
            foreach (String firstNest in lines.GetRange(1,lines.Count-1))
            {
                List<string> values = SplitSecondNest(firstNest);
                foreach (String value in values)
                {
                    ParserCore.AddCellInRowAndGoToNextColumn(value);
                }
                ParserCore.GotoNextRow();
            }
        }

        internal void parseFirstNestAsColumns(List<string> lines)
        {
            foreach (String firstNest in lines)
            {
                List<string> values = SplitSecondNest(firstNest);
                ParserCore.SetColumnName(values.ElementAt(0));
                foreach (String value in values.GetRange(1,values.Count-1))
                {
                    ParserCore.AddNextCellInColumn(value);
                }
                ParserCore.GotoNextColumn();
            }
        }

        internal virtual List<string> SplitSecondNest(string firstNest)
        {
            throw new NotImplementedException();
        }

        internal virtual string parserName { get { return "Asbtract";}}

       internal  bool IsTheSameAs(AbstractParser another)
        {
            return another.parserName.Equals(parserName);
        }
    }
}
