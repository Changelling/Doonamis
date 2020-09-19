using SilliconPower.Backend.Domain.Common;
using SilliconPower.Backend.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.ValueObjects
{
    public class Rating : ValueObject
    {
        public double Score { get; private set; }

        private Rating() { 
        }

        public Rating(double score)
        {
            Score = score;
        }

        /// <summary>
        /// Create a Rating based on score:
        /// </summary>
        /// <exception cref="RatingInvalidException">
        /// Thrown when the score are not between 0 and 5.
        /// </exception>
        public static Rating From(double score)
        {
            if (score > 5)
                throw new RatingInvalidException(score);
            return new Rating(score);
        }

        public static implicit operator double(Rating rating)
        {
            return rating.Score;
        }

        public static implicit operator string(Rating rating)
        {
            return rating.ToString();
        }

        public static explicit operator Rating(double rating)
        {
            return From(rating);
        }

        public override string ToString()
        {
            return $"{Score}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Score;            
        }
    }
}
