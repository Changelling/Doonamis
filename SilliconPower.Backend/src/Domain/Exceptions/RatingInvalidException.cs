using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.Exceptions
{
    public class RatingInvalidException : Exception
    {
        public RatingInvalidException(double score)
            : base($"Rating {score} is invalid. The rating must be between 0-5")
        {
        }
    }
}
