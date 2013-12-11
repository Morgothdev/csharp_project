using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class CountAggregation : Aggregation
    {
        public override Object GetAggregatedValue()
        {
            return this.cells.Count;
        }

        public CountAggregation(List<Cell> cells)
        {
            this.cells = cells;
        }
    }
}