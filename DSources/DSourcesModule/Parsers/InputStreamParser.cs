﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    /**
     * Parser danych ze streamu, IsFinal == false, nie będzie zawierał się w liście ParserInfo zwróconej z DSources.DSourcesFacade
     * Więc jest bezużyteczny dla klienta korzystającego z modułu.
     */
    class InputStreamParser : AbstractParser
    {
        internal override bool IsFinal { get { return false; } }

        internal override bool IsValid { get { return false; } }

        internal override string parserName { get { return "InputStream"; } }
    }
}
