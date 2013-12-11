using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class FilterCommand : Command
    {
        public delegate bool Del(Cell<Object> cell);
        List<int> invalidRows;
        public FilterCommand(Column<Object> column,Del del)
        {
            invalidRows = new List<int>();
            foreach (Cell<Object> cell in column.Cells)
            {
                if (!del.Invoke(cell)) invalidRows.Add(column.Cells.IndexOf(cell));
            }
        }
        public override Table Execute(Table table)
        {
            Table newTable = new Table(table.Name, null, table);
            foreach (Column<Object> column in table.Columns)
            {
                Column<Object> newColumn = new Column<Object>(column.Name, new List<Cell<Object>>(column.Cells), column.Type);
                foreach (int index in invalidRows)
                {
                    newColumn.Cells.RemoveAt(index);
                }
                newTable.AddColumn(newColumn);
            }
            return newTable;
        }
    }
}
