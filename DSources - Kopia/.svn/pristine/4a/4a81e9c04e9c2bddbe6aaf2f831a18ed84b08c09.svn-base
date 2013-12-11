using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    class XMLParser : FileParser
    {
        public override bool IsFinal { get { return true; } }

        public override bool IsValid { get { return false; } }

        public override void Init()
        {
            base.Init();
            Arguments.ParserName = "XML File Parser";
            Arguments.RemoveArgument(InputStreamParser.CELLS_DELIM);
            Arguments.RemoveArgument(InputStreamParser.COLUMN_DELIM);
            Arguments.RemoveArgument(InputStreamParser.ORDER_IN_STREAM);


        }
    }
}
