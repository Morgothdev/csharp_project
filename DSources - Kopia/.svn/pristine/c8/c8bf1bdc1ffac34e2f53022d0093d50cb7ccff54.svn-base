using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class SelectCommand : Command
    {
        protected List<Column<Object>> selectedColumns;
        protected List<int> selectedIndices;
        public SelectCommand(List<Column<Object>> selectedColumns)
        {
            this.selectedColumns = selectedColumns;
        }
        public SelectCommand(List<int> selectedIndeces)
        {
            this.selectedIndices = selectedIndeces;
        }

        public override Table Execute(Table table)
        {
            List<Column<Object>> columns;
            if (selectedIndices == null)
            {
                columns = selectedColumns;
            }
            else
            {
                columns = new List<Column<Object>>();
                foreach (int index in selectedIndices)
                {
                    columns.Add(table.Columns[index]);
                }

            }

            return new Table(table.Name, table.Columns.FindAll(delegate(Column<Object> column)
                {
                    return (selectedColumns.IndexOf(column) != -1);
                }), table);


        }
    }
}
