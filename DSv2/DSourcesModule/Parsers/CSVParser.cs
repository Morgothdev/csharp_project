using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    /**
     * Parser plików CSV.
     */
    class CSVParser : FileParser
    {
        internal override bool IsFinal { get { return true; } }

        internal override bool IsValid { get { return problems.Count == 0; } }

        internal static string Name = "CSV File";

        internal override void Init()
        {
            base.Init();
            Arguments.ParserName = Name;
            Arguments.RemoveArgument(CSVParser.ORDER_IN_DATA);
        }

        internal override InternalParser ClonePrototype()
        {
            InternalParser nev = new CSVParser();
            nev.Init();
            return nev;
        }


        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);
        }

        internal override List<string> SplitFirstNest(string Data)
        {
            List<string> lines = new List<string>();
            StringReader reader = new StringReader(Data);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line.Trim());
            }
            return lines;
        }

        internal override List<string> SplitSecondNest(string line)
        {
            return line.Split(',').Select(s => s.Trim()).ToList();
        }
    }
}
