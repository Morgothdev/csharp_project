using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class FilterCommand : Command
    {
        public delegate bool Del(Object cellContent);
        List<int> invalidRows;
        public FilterCommand(Column column,Del del)
        {
            invalidRows = new List<int>();
            foreach (Cell cell in column.Cells)
            {
                if (!del.Invoke(cell.Content)) invalidRows.Add(column.Cells.IndexOf(cell));
            }
        }
        public override Table Execute(Table table)
        {
            Table newTable = new Table(table.Name, table);
            foreach (Column column in table.Columns)
            {
                Column newColumn = new Column(column.Name, column.Type, new List<Cell>(column.Cells));
                int z = 0;
                foreach (int index in invalidRows)
                {
                    newColumn.Cells.RemoveAt(index-z);
                    z++;
                }
                newTable.AddColumn(newColumn);
            }
            return newTable;
        }
    }
}
