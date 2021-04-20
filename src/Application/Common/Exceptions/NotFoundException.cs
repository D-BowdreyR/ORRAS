using System;

namespace ORRA.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public NotFoundException(string name, object key)
            : base($"A {name} with parameter ='{key}' was not found.")
        {
        }

    }
}