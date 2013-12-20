using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{   
    public class MaxAggregation : Aggregation
    {
        public class BadColumnForMinimizeException : InvalidCastException
        {
            public BadColumnForMinimizeException() : base("Nie można uzyskać minimalnej wartości z kolumny, której typ to FAKT!") { }
        }

        public override Object GetAggregatedValue()
        {
            double max = Double.MinValue;
            foreach(Cell cell in this.cells)
            {
                try
                {
                    if ((double)cell.Content > max) max = (double)cell.Content;
                }
                catch (BadColumnForMinimizeException)
                {
                    throw;
                }
            }
            return max;
        }

        public MaxAggregation(List<Cell> cells)
        {
            this.cells = cells;
        }
    }
}
