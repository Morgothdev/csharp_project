using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UDM;

namespace DSources.Parsers
{
    /**
     * Builder do budowania UDM.Table
     */
    internal class ParserCore
    {
        internal List<List<string>> columns = new List<List<string>>();
        internal List<String> columnNames = new List<string>();
        internal List<DataType> columnDataTypes = new List<DataType>();


        private int actualColumn = 0;
        private string tableName = "anonymous table";

        internal void Init()
        {
            columns.Add(new List<string>());
            actualColumn = 0;
        }

        internal void GotoStart()
        {
            actualColumn = 0;
        }

        private void checkColumns()
        {
            for (int i = columns.Count; i <= actualColumn; ++i)
            {
                columns.Add(new List<string>());
            }
        }

        internal void AddCellInRowAndGoToNextColumn(string cell)
        {
            checkColumns();
            columns.ElementAt(actualColumn).Add(cell);
            //Console.WriteLine("added " + cell);
            ++actualColumn;
        }

        internal void AddNextCellInColumn(string cell)
        {
            checkColumns();
            columns.ElementAt(actualColumn).Add(cell);
        }

        internal void GotoNextColumn()
        {
            ++actualColumn;
        }

        internal void SetTableName(String name)
        {
            tableName = name;
        }

        internal void SetColumnType(DataType Type)
        {
            //Console.WriteLine("added type " + Type.ToString());
            columnDataTypes.Add(Type);
        }

        internal void SetColumnName(String Name)
        {
            columnNames.Add(Name);
           // Console.WriteLine("added name " + Name);
        }

        internal void GotoNextRow()
        {
            actualColumn = 0;
        }

        internal Table Build()
        {

            clearEmptyColumns();

            checkSameLengthsOfColumns();

            checkCompleteData();

            Table result = BuildTable();

            return result;
        }

        private void checkCompleteData()
        {
            if (columns.Count != columnNames.Count) { throw new ArgumentException("Different number of columns and column Names in souce"); }
            if (columns.Count != columnDataTypes.Count) { throw new ArgumentException("Different number of columns and column roles in souce"); }
        }

        private void checkSameLengthsOfColumns()
        {
            //Console.WriteLine("columns length: " + columns.Count);
            if (columns.Count == 0) return;
            int rows = columns[0].Count;
            foreach (List<string> column in columns)
            {
                if (column.Count != rows) { throw new ArgumentException("Condemned rows!"); }
            }
        }

        private void clearEmptyColumns()
        {
            List<List<string>> old = columns;
            columns = new List<List<string>>();
            foreach (List<string> column in old)
            {
                if (column.Count > 0)
                {
                    columns.Add(column);
                }
            }
        }

        private Table BuildTable()
        {
            List<Column> resultColumns = new List<Column>();
            for (int c = 0; c < columns.Count; ++c)
            {
                List<Cell> newColumnCells = columns[c].Select(x => new Cell(CastToValidType(x, columnDataTypes[c]))).ToList();
                Column newColumn = new Column(columnNames[c], columnDataTypes[c], newColumnCells);
                resultColumns.Insert(resultColumns.Count, newColumn);
            }
            return new Table(tableName, null, resultColumns);
        }

        internal object CastToValidType(string x, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.FloatFact:
                    x = x.Replace(',', '.');
                    return Double.Parse(x, CultureInfo.InvariantCulture);
                case DataType.IntegerFact:
                    return Int64.Parse(x);
                case DataType.StringDimension:
                    break;
                case DataType.DateDimension:
                    break;
            }
            return x;
        }

        public override String ToString()
        {
            clearEmptyColumns();

            checkSameLengthsOfColumns();

            checkCompleteData();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < columns.Count; ++i)
            {
                result.Append("Column, name: \"" + columnNames[i] + "\", role: " + columnDataTypes[i] + ", cells: ");
                foreach (Object cell in columns[i])
                {
                    result.Append(cell + " | ");
                }
                result.AppendLine();
            }
            return result.ToString();

        }
    }
}
