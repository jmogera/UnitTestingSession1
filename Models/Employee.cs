using System;
using System.Collections.Generic;

namespace Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        public Dictionary<DateTime, double> SalaryHistory { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
