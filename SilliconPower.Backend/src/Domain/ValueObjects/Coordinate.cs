using SilliconPower.Backend.Domain.Common;
using SilliconPower.Backend.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.ValueObjects
{
    /// <summary>
    /// Location Coordinates:
    ///     It is a Value Object that allows creating a location with latitude;longitude
    /// </summary>
    public class Coordinate : ValueObject
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        private const double EarthRadius = 6371;

        private Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Create a Location based on latitude,longitude coordinates string:
        /// </summary>
        /// <exception cref="CoordinateInvalidException">
        /// Thrown when the coordinates are not in the correct format.
        /// </exception>
        public static Coordinate For(string coordinates)
        {
            try
            {
                var position = coordinates.Split(",");
                var latitude = double.Parse(position[0]);
                var longitude = double.Parse(position[1]);
                return new Coordinate(latitude, longitude);
            }
            catch (Exception ex)
            {
                throw new CoordinateInvalidException(coordinates, ex);
            }
        }

        /// <summary>
        /// Gets the distance between this location an another:
        /// </summary>
        /// <exception cref="DistanceInvalidException">
        /// Thrown when the distance cant be calculated.
        /// </exception>
        public double GetDistanceFrom(Coordinate point)
        {
            try
            {
                double distance = 0;
                double Lat = (point.Latitude - this.Latitude) * (Math.PI / 180);
                double Lon = (point.Longitude - this.Longitude) * (Math.PI / 180);
                double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(this.Latitude * (Math.PI / 180)) * Math.Cos(point.Latitude * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                distance = EarthRadius * c;
                return distance;
            }
            catch (Exception ex)
            {
                throw new DistanceInvalidException(point, ex);
            }
        }

        public static implicit operator string(Coordinate location)
        {
            return location.ToString();
        }

        public static explicit operator Coordinate(string coordinates)
        {
            return For(coordinates);
        }

        public override string ToString()
        {
            return $"{Latitude},{Longitude}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}
