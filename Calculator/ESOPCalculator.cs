using Calculator.Models;
using Models;
using Models.Exceptions;
using System;
using System.Collections.Generic;

namespace Calculator
{
    public class ESOPCalculator
    {
        private readonly Company company;

        public ESOPCalculator(Company company)
        {
            if (company == null)
            {
                throw new Exception("Company Can't be null");
            }

            if(company.Id <= 0)
            {
                throw new InvalidCompanyIdException();
            }

            if(company.Employees.Count <= 0)
            {
                throw new NoEmployeesException();
            }

            this.company = company;
        }

        public List<ESOPStatement> CalculateStatement()
        {
            List<ESOPStatement> statements = new List<ESOPStatement>();
            foreach (var employee in company.Employees)
            {
                //Employee Start Date
                if(employee.StartDate.Year >= company.ESOPStartDate.Year && !employee.EndDate.HasValue)
                {
                    double numberOfShares = 0;
                    foreach(var history in employee.SalaryHistory)
                    {
                        numberOfShares += history.Value * (10 / 100);
                    }
                    statements.Add(new ESOPStatement()
                    {
                        EmployeeId = employee.Id,
                        NumOfShares = numberOfShares,
                        SharePrice = company.ShareValue,
                    });
                }
            }

            return statements;
        }

    }
}
