using AutoMapper;
using SilliconPower.Backend.Application.Common.Mappings;
using SilliconPower.Backend.Domain.Entities;
using NUnit.Framework;
using System;
using SilliconPower.Backend.Application.Entities;

namespace SilliconPower.Backend.Application.UnitTests.Common.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        
        [Test]
        [TestCase(typeof(Activity), typeof(ActivityDto))]
        [TestCase(typeof(Assessment), typeof(AssessmentDto))]        
        [TestCase(typeof(Category), typeof(CategoryDto))]
        [TestCase(typeof(Image), typeof(ImageDto))]
        [TestCase(typeof(Location), typeof(LocationDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
