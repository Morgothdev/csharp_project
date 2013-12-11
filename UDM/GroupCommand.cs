using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class GroupCommand : Command
    {
        protected List<Column> groupingColumns;
        protected Dictionary<Column,Aggregation> aggregatedColumns;

        public class AllColumnsShouldBeSelectedForGroupingException : Exception
        {
            public AllColumnsShouldBeSelectedForGroupingException() : base("Do grupowania trzeba wybrać wszystkie kolumny z tabeli!") { }
        }

        public class BadColumnsChooseForAggregationException : Exception
        {
            public BadColumnsChooseForAggregationException() : base("Nie można agregować kolumn typu WYMIAR") { }
        }

        public class BadColumnsChooseForGroupingException : Exception
        {
            public BadColumnsChooseForGroupingException() : base("Nie można grupować po kolumnach typu FAKT") { }
        }

        public GroupCommand(List<Column> groupingColumns, Dictionary<Column,Aggregation> aggregatedColumns)
        {
            this.groupingColumns = groupingColumns;
            this.aggregatedColumns = aggregatedColumns;
        }

        public override Table Execute(Table table)
        {   
            foreach(Column column in groupingColumns)
            {
                if (column.Type != DataType.Dimension) throw new BadColumnsChooseForGroupingException();
            }
            foreach(Column column in aggregatedColumns.Keys)
            {
                if (column.Type == DataType.Dimension) throw new BadColumnsChooseForAggregationException();
            }
            if ((groupingColumns.Count + aggregatedColumns.Count) != table.Columns.Count)
                throw new AllColumnsShouldBeSelectedForGroupingException();


            

            // TODO
            return new Table("jan",null, new List<Column>());
        }
    }
}
