using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class VerticalJoinCommand : Command
    {
        public class IncoherentColumnCountException : Exception
        {
            public IncoherentColumnCountException() : base("Ilości kolumn w tabelach nie zgadzają się!") { }
        }
        public class ColumnTypeMismatchException : Exception
        {
            public ColumnTypeMismatchException() : base("Łączone kolumny powinny mieć ten sam typ!") { }
        }
        protected Table secondTable;
        public VerticalJoinCommand(Table table)
        {
            secondTable = table;
        }

        public override Table Execute(Table firstTable)
        {
            Table newTable = new Table(firstTable.Name, firstTable);
            if (firstTable.Columns.Count != secondTable.Columns.Count) throw new IncoherentColumnCountException();
            for (int i = 0; i < firstTable.Columns.Count; i++)
            {
                if (firstTable.Columns[i].Type != secondTable.Columns[i].Type) throw new ColumnTypeMismatchException();
                Column newColumn = new Column(firstTable.Columns[i].Name, firstTable.Columns[i].Type, new List<Cell>(firstTable.Columns[i].Cells));
                newColumn.Cells.AddRange(secondTable.Columns[i].Cells);
                newTable.AddColumn(newColumn);
            }
            return newTable;
        }
    }
}