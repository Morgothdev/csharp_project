using System;
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
        internal String COLUMNS_ROLES_KEY = "Columns roles list";
        internal String COLUMN_OBJECT_TYPES_KEY = "Object type in columns";
        internal String COLUMNS_COUNT_KEY = "Column count";

        private ParserInfo _arguments = new ParserInfo();

        internal ParserCore ParserCore { get; set; }

        public ParserInfo Arguments { get { return _arguments; } }

        public virtual bool IsFinal { get { return false; } }

        public virtual bool IsValid { get { return false; } }

        public AbstractParser() {
            ParserCore = new ParserCore();
        }

        public virtual InternalParser ClonePrototype()
        {
            throw new NotImplementedException();
        }

        public virtual void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public virtual void Init()
        {
            ParserArgumentInfo column_object_types = new ParserArgumentInfo(COLUMN_OBJECT_TYPES_KEY, ArgType.Text, "List of object types in columns, in format: \"<object_type> , <object_type> , (...)\" where <object_type> is one of: Text, Number, Date");
            ParserArgumentInfo columns_roles = new ParserArgumentInfo(COLUMNS_ROLES_KEY, ArgType.Text, "List of role of each column, in format: \"<role> , <role> , (...)\" where <role> is one of: Fact, Dimension");
            Arguments.AddArgument(column_object_types);
            Arguments.AddArgument(columns_roles);
        }

        public bool RowsInFirstNest = true;

        public virtual Table Parse()
        {
            ParseData();
            return ParserCore.Build();
        }

        internal void ParseData()
        {
            ParserCore.Init();
            string data = ReadData();
            string[] lines = SplitFirstNest(data);
            if (RowsInFirstNest)
            {
                parseFirstNestAsRows(lines);
            }
            else
            {
                parseFirstNestAsColumns(lines);
            }
        }

        internal virtual string ReadData()
        {
            throw new NotImplementedException();
        }

        internal virtual string[] SplitFirstNest(string Data)
        {
            throw new NotImplementedException();
        }

        internal void parseFirstNestAsRows(string[] lines)
        {
            foreach (String firstNest in lines)
            {
                string[] values = SplitSecondNest(firstNest);
                foreach (String value in values)
                {
                    ParserCore.AddNextCellInRow(value);
                }
                ParserCore.GotoNextRow();
            }
        }

        internal void parseFirstNestAsColumns(string[] lines)
        {
            foreach (String firstNest in lines)
            {
                string[] values = SplitSecondNest(firstNest);
                foreach (String value in values)
                {
                    ParserCore.AddNextCellInColumn(value);
                }
                ParserCore.GotoNextColumn();
            }
        }

        internal virtual string[] SplitSecondNest(string firstNest)
        {
            throw new NotImplementedException();
        }
    }
}
