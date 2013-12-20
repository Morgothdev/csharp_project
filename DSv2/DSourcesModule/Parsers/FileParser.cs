using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM;

namespace DSources.Parsers
{
    /**
     * Parser czytający z pliku, wymaga podania w argumentach dodatkowo ścieżki do pliku.
     */

    class FileParser : InputStreamParser
    {
        internal static String FILE_PATH_KEY = "File path";

        internal override bool IsFinal { get { return false; } }

        internal string FilePath { get; set; }

        internal override InternalParser ClonePrototype()
        {
            return new FileParser();
        }

        internal override void Init()
        {
            base.Init();
            ParserArgumentInfo file_path = new ParserArgumentInfo(FILE_PATH_KEY, ArgType.File, "Path of file to read");

            Arguments.AddArgument(file_path);
        }

        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);
            string path = configuration.GetProperty(FILE_PATH_KEY);
            if (path == null || path.Trim().Equals(""))
            {
                problems.Add("Absent argument " + FILE_PATH_KEY);
                if (R.DEBUG) Console.WriteLine("Absent argument " + FILE_PATH_KEY);
                return;
            }
            FileStream file = null;
            try
            {
                file = File.OpenRead(path);
                if (!file.CanRead)
                {
                    problems.Add("Unreadable file");
                    if (R.DEBUG) Console.WriteLine("cant read");
                }
                file.Close();
            }
            catch (Exception e)
            {
                problems.Add("Exception with operating on file: " + e.Message);
                if (R.DEBUG) Console.WriteLine("exception");
                if (file != null) file.Close();
            }
            FilePath = path;
            if (R.DEBUG) Console.WriteLine("path setted: " + FilePath);
        }

        internal override string ReadData()
        {
            return File.ReadAllText(FilePath);
        }

        internal override string parserName { get { return "File"; } }

    }
}
