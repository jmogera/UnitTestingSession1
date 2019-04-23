using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Models
{
    public class ESOPStatement
    {
        public int EmployeeId { get; set; }
        public double NumOfShares { get; set; }

        public double SharePrice { get; set; }
        public double FinalBalance
        {
            get
            {
                return NumOfShares* SharePrice;
            }
        }
    }
}
