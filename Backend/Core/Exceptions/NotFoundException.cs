using System;

namespace Core.Exceptions
{
    /// <summary>
    /// Returns a 404 exception to the client
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
