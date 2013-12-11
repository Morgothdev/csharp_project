using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    class InputStreamParser : AbstractParser
    {
        internal override bool IsFinal { get { return false; } }

        internal override bool IsValid { get { return false; } }

        internal override string parserName { get { return "InputStream"; } }
    }
}
