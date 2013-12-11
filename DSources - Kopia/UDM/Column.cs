using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public  class Column<T>
    {
        public DataType Type;

        public string Name;

        public List<Cell<T>> Cells;

        public Column(string name, List<Cell<T>> cells, DataType type) { }

        public void AddCell(Cell<T> cell) { }

        public bool RemoveCell(Cell<T> cell) { return false; }
    }
}
