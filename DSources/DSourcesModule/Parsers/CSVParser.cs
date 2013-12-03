﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM;

namespace DSources.Parsers
{
    class CSVParser : FileParser
    {
        private bool _valid = false;

        public override bool IsFinal { get { return true; } }

        public override bool IsValid { get { return _valid; } }

        public override void Init()
        {
            base.Init();
            Arguments.ParserName = "CSV File Parser";
            Arguments.RemoveArgument(InputStreamParser.CELLS_DELIM);
            Arguments.RemoveArgument(InputStreamParser.COLUMN_DELIM);
            Arguments.RemoveArgument(InputStreamParser.ORDER_IN_STREAM);
        }

        public override InternalParser ClonePrototype()
        {
            return new CSVParser();
        }

        
        public override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);
        }

        internal override string[] SplitFirstNest(string Data)
        {
            string[] separators = { System.Environment.NewLine};
            return Data.Split(separators, StringSplitOptions.None);
        }

        internal override string[] SplitSecondNest(string line)
        {
            return line.Split(',');
        }

    }
}