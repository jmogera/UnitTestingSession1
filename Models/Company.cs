using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Company
    {
        public Company()
        {
            Employees = new List<Employee>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ESOPStartDate { get; set; }

        public double ShareValue { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
