using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.Exceptions
{
    public class CoordinateInvalidException : Exception
    {
        public CoordinateInvalidException(string coordinates, Exception ex)
            : base($"Location {coordinates} is invalid. The format must be 'latitude,longitude'", ex)
        {
        }
    }
}
