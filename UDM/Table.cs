using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class Table
    {
        protected List<Column> columns;
        protected string _name;
        protected Table previous;
        public string Name
        {
            get { return _name; }
        }

        public List<Column> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public Table(String _name, Table previous, List<Column> columns = null)
        {
            this._name = _name;
            if (columns == null) this.columns = new List<Column>();
            else this.columns = columns;
            this.previous = previous;
        }

        public void AddColumn(Column column)
        {
            this.columns.Add(column);
        }

        public bool RemoveColumn(Column column)
        {
            return columns.Remove(column);
        }

        public override String ToString()
        {
            String table = this.Name + "\n";
            foreach (Column column in this.columns)
            {
                table += column.ToString();
                table += "\n";
            }
            return table;
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
