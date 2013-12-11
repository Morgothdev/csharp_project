using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM;

namespace DSources.Parsers
{
    internal class ParserCore
    {
        private List<List<Object>> columns = new List<List<Object>>();
        private List<String> columnNames = new List<string>();
        private List<DataType> columnDataTypes = new List<DataType>();
        private List<ObjectType> columnObjectsTypes = new List<ObjectType>();


        private int actualColumn = 0;

        internal void Init() {
            columns.Add(new List<Object>());
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
                columns.Add(new List<Object>());
            }
        }

        internal void AddCellInRowAndGoToNextColumn(Object cell) {
            checkColumns();
            columns.ElementAt(actualColumn).Add(cell);
            ++actualColumn;
        }

        internal void AddNextCellInColumn(Object cell) {
            columns.ElementAt(actualColumn).Add(cell);
        }

        internal void GotoNextColumn() {
            ++actualColumn;
            checkColumns();
        }

        internal void SetColumnType(DataType Type) {
            columnDataTypes.Add(Type);
        }

        internal void SetColumnName(String Name) {
            columnNames.Add(Name);
        }

        internal void SetColumnObjectsType(ObjectType objectsType)
        {
            columnObjectsTypes.Add(objectsType);
        }

        internal void GotoNextRow() {
            actualColumn = 0;
        }

        internal Table Build() {

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
            if (columns.Count != columnObjectsTypes.Count) { throw new ArgumentException("Different number of columns and column object types in souce"); }
        }

        private void checkSameLengthsOfColumns()
        {
            int rows = columns[0].Count;
            foreach (List<Object> column in columns)
            {
                if (column.Count != rows) { throw new ArgumentException("Condemned rows!"); }
            }
        }

        private void clearEmptyColumns()
        {
            List<List<object>> old = columns;
            columns = new List<List<object>>();
            foreach (List<Object> column in old)
            {
                if (column.Count > 0)
                {
                    columns.Add(column);
                }
            }
        }

        private Table BuildTable()
        {
            Table result = new Table("", new List<Column<object>>());
            for (int c = 0; c < columns.Count; ++c)
            {
                List<Cell<Object>> newColumnCells = columns[c].Select(x => new Cell<object>(x)).ToList();
                Column<Object> newColumn = new Column<object>(columnNames[c], newColumnCells, columnDataTypes[c]);
                result.AddColumn(newColumn);
            }
            return result;
        }

        public override String ToString(){

            clearEmptyColumns();

            checkSameLengthsOfColumns();

            checkCompleteData();

            StringBuilder result = new StringBuilder();
            for(int i = 0; i<columns.Count;++i)
            {
                result.Append("Column, name: \"" + columnNames[i] + "\", objects type: " + columnObjectsTypes[i] + ", role: " + columnDataTypes[i] + ", cells: ");
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
