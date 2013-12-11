﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM;

namespace DSources.Parsers
{
    internal class ParserCore
    {
        private List<List<string>> columns = new List<List<string>>();
        private List<String> columnNames = new List<string>();
        private List<DataType> columnDataTypes = new List<DataType>();


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
            ++actualColumn;
        }

        internal void AddNextCellInColumn(string cell)
        {
            columns.ElementAt(actualColumn).Add(cell);
        }

        internal void GotoNextColumn()
        {
            ++actualColumn;
            checkColumns();
        }

        internal void SetTableName(String name)
        {
            tableName = name;
        }

        internal void SetColumnType(DataType Type)
        {
            columnDataTypes.Add(Type);
        }

        internal void SetColumnName(String Name)
        {
            columnNames.Add(Name);
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

        private object CastToValidType(string x, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.FloatFact:
                    return Double.Parse(x);
                case DataType.IntegerFact:
                    return Int64.Parse(x);
                case DataType.Dimension:
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
