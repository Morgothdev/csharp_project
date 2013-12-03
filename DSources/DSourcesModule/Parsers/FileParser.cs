﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM;

namespace DSources.Parsers
{
    class FileParser : InputStreamParser
    {
        internal static String FILE_PATH_KEY = "File path";

        private bool _valid = false;

        public override bool IsFinal { get { return true; } }

        public override bool IsValid { get { return _valid; } }

        internal string FilePath { get; set; }

        public override void Init()
        {
            base.Init();
            Arguments.ParserName = "File Parser";
            ParserArgumentInfo file_path = new ParserArgumentInfo(FILE_PATH_KEY, ArgType.File, "Path of file to read");

            Arguments.AddArgument(file_path);
        }

        public override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            string path = configuration.GetProperty(FILE_PATH_KEY);
            try
            {
                FileStream file = File.OpenRead(path);
                if (!file.CanRead)
                {
                    _valid = false;
                }
                file.Close();
            }
            catch (Exception)
            {
                _valid = false;
            }
            FilePath = path;
        }

        internal override string ReadData()
        {
            return File.ReadAllText(FilePath);
        }
    }
}