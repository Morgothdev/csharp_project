using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class MinAggregation : Aggregation
    {
        public class BadColumnForMaximizeException : InvalidCastException
        {
            public BadColumnForMaximizeException() : base("Nie można uzyskać maksymalnej wartości z kolumny, której typ to FAKT!") { }
        }

        public override Object GetAggregatedValue()
        {
            double min = Double.MaxValue;
            foreach (Cell cell in this.cells)
            {
                try
                {
                    if ((double)cell.Content < min) min = (double)cell.Content;
                }
                catch (BadColumnForMaximizeException)
                {
                    throw;
                }
            }
            return min;
        }

        public MinAggregation(List<Cell> cells)
        {
            this.cells = cells;
        }
    }
}
