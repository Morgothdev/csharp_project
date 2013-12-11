﻿using System;
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

        internal override bool IsFinal { get { return true; } }

        internal override bool IsValid { get { return problems.Count == 0; } }

        internal string FilePath { get; set; }

        internal override void Init()
        {
            base.Init();
            Arguments.ParserName = "File Parser";
            ParserArgumentInfo file_path = new ParserArgumentInfo(FILE_PATH_KEY, ArgType.File, "Path of file to read");

            Arguments.AddArgument(file_path);
        }

        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);
            string path = configuration.GetProperty(FILE_PATH_KEY);
            try
            {
                FileStream file = File.OpenRead(path);
                if (!file.CanRead)
                {
                    problems.Add("Unreadable file");
                   //Console.WriteLine("cant read");
                }
                file.Close();
            }
            catch (Exception)
            {
                problems.Add("Exception with operating on file");
                Console.WriteLine("exception");
            }
            FilePath = path;
//            Console.WriteLine("path setted: " + FilePath);
        }

        internal override string ReadData()
        {
            return File.ReadAllText(FilePath);
        }

        internal override string parserName { get { return "File"; } }

    }
}
