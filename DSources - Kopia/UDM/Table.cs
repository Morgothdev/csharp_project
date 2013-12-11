using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class Table
    {
        public string Name;
        public List<Column<Object>> Columns;
        public Table(String _name, List<Column<Object>> columns, Table previous = null) { }
        public void AddColumn(Column<Object> column) { }
        public bool RemoveColumn(Column<Object> column) { return false; }
        public Table Execute(Command command) { return null; }
        public Table Undo() { return null; }
        public Table Normalize() { return null; }
    }
}
