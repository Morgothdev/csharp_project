using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class SelectCommand : Command
    {
        protected List<Column> selectedColumns;
        protected List<int> selectedIndices;
        public SelectCommand(List<Column> selectedColumns)
        {
            this.selectedColumns = selectedColumns;
        }
        public SelectCommand(List<int> selectedIndeces)
        {
            this.selectedIndices = selectedIndeces;
        }

        public override Table Execute(Table table)
        {
            if (selectedIndices != null)
            {
                selectedColumns = new List<Column>();
                foreach (int index in selectedIndices)
                {
                    selectedColumns.Add(table.Columns[index]);
                }

            }
            return new Table(table.Name, null, selectedColumns);
        }
    }
}
