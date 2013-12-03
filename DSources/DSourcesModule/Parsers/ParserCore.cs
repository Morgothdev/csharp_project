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

        private int actualColumn = 0;
        private int actualRow = 0;

        internal void Init() {
            columns.Add(new List<Object>());
            actualColumn = 0;
            actualRow = 0;
        }

        private void checkColumns()
        {
            for (int i = columns.Count; i <= actualColumn; ++i)
            {
                columns.Add(new List<Object>());
            }
        }

        internal void AddNextCellInRow(Object cell) {
            ++actualColumn;
            checkColumns();
            columns.ElementAt(actualColumn).Add(cell);
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

        internal void GotoNextRow() {
            actualColumn = 0;
        }

        internal Table Build() {
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
            StringBuilder result = new StringBuilder();
            foreach (List<Object> column in columns)
            {
                foreach (Object cell in column)
                {
                    result.Append(cell + " | ");
                }
                result.AppendLine();
            }
            return result.ToString();

        }
    }
}
