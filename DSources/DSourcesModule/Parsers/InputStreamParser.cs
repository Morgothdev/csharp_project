﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    class InputStreamParser : AbstractParser
    {
        public override bool IsFinal { get { return true; } }

        public override bool IsValid { get { return false; } }

        internal static String CELLS_DELIM = "Cells delimeter";
        internal static String COLUMN_DELIM = "Columns delimeter";
        internal static String ORDER_IN_STREAM = "Order in stream";

        public override void Init()
        {
            base.Init();
            Arguments.ParserName = "Input Stream Parser";
            ParserArgumentInfo cells_delimeter = new ParserArgumentInfo(CELLS_DELIM, ArgType.Text, "Delimeter for delim cells in input stream");
            ParserArgumentInfo columns_delimeter = new ParserArgumentInfo(COLUMN_DELIM, ArgType.Text, "Delimeter for delim columns in input stream");
            ParserArgumentInfo order_in_stream = new ParserArgumentInfo(ORDER_IN_STREAM, ArgType.Text, "Sequence in the stream, that is, either column by column(value: \"column\") or row by row (value: \"row\")");
            Arguments.AddArgument(cells_delimeter);
            Arguments.AddArgument(columns_delimeter);
            Arguments.AddArgument(order_in_stream);
        }
    }
}
