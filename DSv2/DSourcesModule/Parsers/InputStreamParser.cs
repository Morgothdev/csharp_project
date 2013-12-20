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

        public static string ORDER_IN_DATA = "Order in data";

        internal override bool IsFinal { get { return false; } }

        internal override string parserName { get { return "InputStream"; } }

        internal bool RowsInFirstNest { get; set; }

        internal override void ConfigureItSelf(Logic.ParserConfiguration configuration)
        {
            base.ConfigureItSelf(configuration);
            if (Arguments.ContainsArgument(ORDER_IN_DATA))
            {
                //Console.WriteLine(configuration.GetProperty(ORDER_IN_DATA).ToLower());
                string order = configuration.GetProperty(ORDER_IN_DATA);

                if (order == null)
                {
                    problems.Add("Absent argument: " + ORDER_IN_DATA);
                    Console.WriteLine("Absent argument: " + ORDER_IN_DATA);
                }
                else
                {
                    order = order.ToLower();
                    if (!order.Equals("row by row") && !order.Equals("column by column"))
                    {
                        problems.Add("Unrecognized order: " + order);
                        Console.WriteLine("Unrecognized order: " + order);
                    }
                    RowsInFirstNest = order.Equals("row by row");
                }
            }
            else
            {
                RowsInFirstNest = true;
            }

            //Console.WriteLine("abstract configured: " + roles + "|" + objectTypes);
        }

        internal override void Init()
        {
            base.Init();
            ParserArgumentInfo order_in_data = new ParserArgumentInfo(ORDER_IN_DATA, ArgType.Enum, "Order in the data whether or column by column or row by row", "row by row,column by column");

            Arguments.AddArgument(order_in_data);
        }

        internal override void Read()
        {
            string data = ReadData();

            List<string> lines = SplitFirstNest(data);

            if (RowsInFirstNest)
            {
                parseFirstNestAsRows(lines);
            }
            else
            {
                parseFirstNestAsColumns(lines);
            }
        }


        internal void parseFirstNestAsRows(List<string> lines)
        {
            foreach (String columnName in SplitSecondNest(lines.ElementAt(0)))
            {
                ParserCore.SetColumnName(columnName);
            }
            ParserCore.GotoStart();
            foreach (String firstNest in lines.GetRange(1, lines.Count - 1))
            {
                List<string> values = SplitSecondNest(firstNest);
                foreach (String value in values)
                {
                    ParserCore.AddCellInRowAndGoToNextColumn(value);
                }
                ParserCore.GotoNextRow();
            }
        }

        internal void parseFirstNestAsColumns(List<string> lines)
        {
            foreach (String firstNest in lines)
            {
                List<string> values = SplitSecondNest(firstNest);
                ParserCore.SetColumnName(values.ElementAt(0));
                foreach (String value in values.GetRange(1, values.Count - 1))
                {
                    ParserCore.AddNextCellInColumn(value);
                }
                ParserCore.GotoNextColumn();
            }
        }

    }
}
