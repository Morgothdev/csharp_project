using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSources.Parsers
{
    /**
     * Czytnik plików XLS, do wersji 2003 włącznie.
     * Wymaga podania ścieżki do pliku oraz ról wczytanych kolumn."
     */
    class XLSParser : FileParser
    {
        public static string WORK_SHEET_NAME_KEY = "WorkSheet Name";


        internal override bool IsFinal { get { return true; } }

        internal string workSheetName = null;
        public static string Name = "Excel File";

        internal override InternalParser ClonePrototype()
        {
            InternalParser nev = new XLSParser();
            nev.Init();
            return nev;
        }

        internal override void Init()
        {
            base.Init();
            Arguments.ParserName =Name;
            Arguments.RemoveArgument(ORDER_IN_DATA);
            ParserArgumentInfo workSheetName = new ParserArgumentInfo(WORK_SHEET_NAME_KEY, ArgType.Text, "The name of the work sheet from which the parser will read");
            Arguments.AddArgument(workSheetName);
        }

        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);
            if (Arguments.ContainsArgument(WORK_SHEET_NAME_KEY))
            {
                //Console.WriteLine(configuration.GetProperty(WORK_SHEET_NAME_KEY).ToLower());
                workSheetName = configuration.GetProperty(WORK_SHEET_NAME_KEY);
                Console.WriteLine("worksheet: " + workSheetName);
                if (workSheetName == null)
                {
                    problems.Add("Absent argument: " + WORK_SHEET_NAME_KEY);
                    return;
                }
            }
        }

        internal override void Read()
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=Excel 8.0");
            string sql = "select * from [" + workSheetName + "$]";
            Console.WriteLine(sql);
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataColumn column in dt.Columns)
            {
                if (R.DEBUG) Console.WriteLine("name: " + column.ColumnName);
                ParserCore.SetColumnName(column.ColumnName);
                foreach (DataRow row in dt.Rows)
                {
                    if (R.DEBUG) Console.WriteLine("cell: " + row[column].ToString());
                    ParserCore.AddNextCellInColumn(row[column].ToString());
                }
                ParserCore.GotoNextColumn();
            }
        }


        internal override string parserName { get { return "File"; } }
    }
}
