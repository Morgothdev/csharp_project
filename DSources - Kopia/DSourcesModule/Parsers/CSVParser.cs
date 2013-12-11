﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    class CSVParser : FileParser
    {
        internal override bool IsFinal { get { return true; } }

        internal override bool IsValid { get { return problems.Count==0; } }

        internal override void Init()
        {
            base.Init();
            Arguments.ParserName = "CSV File Parser";
            Arguments.RemoveArgument(AbstractParser.ORDER_IN_DATA);
        }

        internal override InternalParser ClonePrototype()
        {
            return new CSVParser();
        }


        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);

        }

        internal override List<string> SplitFirstNest(string Data)
        {
            string[] separators = { System.Environment.NewLine};

            return Data.Split(separators, StringSplitOptions.None).Select(s => s.Trim()).ToList();
        }

        internal override List<string> SplitSecondNest(string line)
        {
            return line.Split(',').Select(s=> s.Trim()).ToList();
        }

        internal override string parserName { get { return "CSV"; } }

    }
}