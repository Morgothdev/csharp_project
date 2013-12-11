using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class Column<T>
    {
        protected List<Cell<T>> cells;
        protected string _name;
        protected DataType _type;
        public DataType Type
        {
            get { return _type; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Cell<T>> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        public Column(string name, List<Cell<T>> cells, DataType type)
        {
            this._name = name;
            this.cells = cells;
            this._type = type;
        }

        public void AddCell(Cell<T> cell)
        {
            this.cells.Add(cell);
        }

        public bool RemoveCell(Cell<T> cell)
        {
            return cells.Remove(cell);
        }
    }
}
