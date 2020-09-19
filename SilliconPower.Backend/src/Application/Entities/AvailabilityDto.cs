using AutoMapper;
using SilliconPower.Backend.Application.Common.Mappings;
using SilliconPower.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Application.Entities
{
    public class AvailabilityDto : IMapFrom<Availability>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Availability, AvailabilityDto>();
        }
    }
}
