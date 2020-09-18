using AutoMapper;
using SilliconPower.Backend.Application.Common.Mappings;
using SilliconPower.Backend.Domain.Entities;
using SilliconPower.Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Application.Entities
{
    public class ActivityDto : IMapFrom<Activity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }
        public LocationDto Location { get; set; }

        public CategoryDto Category { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Activity, ActivityDto>();
        }

    }
}
