using System;
namespace TesteUol.Entities
{
    public class ForecastIOException : Exception
    {
        public ForecastIOException(string message)
            : base(message)
        {
        }

        public ForecastIOException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

