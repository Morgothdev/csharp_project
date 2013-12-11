using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class Table
    {
        protected List<Column<Object>> columns;
        protected string _name;
        protected Table previous;
        public string Name
        {
            get { return _name; }
        }

        public List<Column<Object>> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public Table(String _name, List<Column<Object>> scolumns, Table previous = null)
        {
            this._name = _name;
            this.columns = scolumns;
            this.previous = previous;
        }

        public void AddColumn(Column<Object> column)
        {
            this.columns.Add(column);
        }

        public bool RemoveColumn(Column<Object> column)
        {
            return columns.Remove(column);
        }

        public Table Execute(Command command)
        {
            return command.Execute(this);
        }

        public Table Undo()
        {
            return previous;
        }
        public Table Normalize()
        {
            return null;
        }
    }
}
