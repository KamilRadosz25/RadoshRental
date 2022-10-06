using System;

namespace RentCarApi.Exceptions
{
    public class NotFoundException :Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
