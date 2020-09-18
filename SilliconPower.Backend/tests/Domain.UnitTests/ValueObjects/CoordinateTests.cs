using SilliconPower.Backend.Domain.Exceptions;
using SilliconPower.Backend.Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace SilliconPower.Backend.Domain.UnitTests.ValueObjects
{
    public class CoordinateTests
    {
        [Test]
        public void ShouldHaveCorrectLatitudeAndLongitude()
        {
            const string coordinateString = "0.002,0.005";

            var coordinate = Coordinate.For(coordinateString);

            coordinate.Latitude.Should().Be(0.002);
            coordinate.Longitude.Should().Be(0.005);
        }

        [Test]
        public void ToStringReturnsCorrectFormat()
        {
            const string coordinateString = "0.002,0.005";

            var coordinate = Coordinate.For(coordinateString);

            var result = coordinate.ToString();

            result.Should().Be(coordinateString);
        }

        [Test]
        public void ImplicitConversionToStringResultsInCorrectString()
        {
            const string coordinateString = "0.002,0.005";

            var coordinate = Coordinate.For(coordinateString);

            string result = coordinate;

            result.Should().Be(coordinateString);
        }

        [Test]
        public void ExplicitConversionFromStringSetsLatitudeAndLongitude()
        {
            const string coordinateString = "0.002,0.005";

            var coordinate = (Coordinate)coordinateString;

            coordinate.Latitude.Should().Be(0.002);
            coordinate.Longitude.Should().Be(0.005);
        }

        [Test]
        public void ShouldThrowCoordinateInvalidExceptionForInvalidCoordinate()
        {
            FluentActions.Invoking(() => (Coordinate)"Sample")
                .Should().Throw<CoordinateInvalidException>();
        }
    }
}
