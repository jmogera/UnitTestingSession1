using System;

namespace Models.Exceptions
{
    public class NoEmployeesException : Exception
    {
        public NoEmployeesException()
            :base("There are employee for the calculator to work! Duh!")
        {

        }
    }
}