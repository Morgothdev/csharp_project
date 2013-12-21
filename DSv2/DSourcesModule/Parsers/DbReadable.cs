using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    internal interface DbReadable
    {
        DbConnection GetConnectionToBase();

        ParserCore GetParserCore();

        DbCommand GetDbCommand();
    }
}
