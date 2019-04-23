using System;

namespace Models.Exceptions
{
    public class InvalidCompanyIdException : Exception
    {
        public InvalidCompanyIdException()
            :base("Company Id is not good")
        {

        }
    }
}