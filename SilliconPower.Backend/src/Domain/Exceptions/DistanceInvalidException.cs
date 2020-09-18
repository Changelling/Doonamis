using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.Exceptions
{
    public class DistanceInvalidException : Exception
    {
        public DistanceInvalidException(string coordinates, Exception ex)
            : base($"Distance between {coordinates} is invalid.", ex)
        {
        }
    }
}
