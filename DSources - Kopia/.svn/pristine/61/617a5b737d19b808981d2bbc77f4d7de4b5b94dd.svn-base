using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class HorizontalJoinCommand : Command
    {
        protected Table secondTable;
        public HorizontalJoinCommand(Table table)
        {
            secondTable = table;
        }
        public override Table Execute(Table firstTable)
        {
            Table newTable = new Table(firstTable.Name,new List<Column<Object>>(firstTable.Columns),firstTable);
            foreach (Column<Object> column in secondTable.Columns)
            {
                bool found = false;
                foreach (Column<Object> columnInFirst in firstTable.Columns)
                {
                    if (column.Name == columnInFirst.Name)
                        found = true;
                }
                if (!found) newTable.AddColumn(column);
            }
            return newTable.Normalize();
        }
    }
}
