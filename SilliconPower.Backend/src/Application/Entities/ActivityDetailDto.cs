using AutoMapper;
using SilliconPower.Backend.Application.Common.Mappings;
using SilliconPower.Backend.Domain.Entities;
using SilliconPower.Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Application.Entities
{
    public class ActivityDetailDto : ActivityDto, IMapFrom<Activity>
    {
        public IList<ImageDto> Images { get; set; }
        public IList<AvailabilityDto> Availabilities { get; set; }
        public IList<AssessmentDto> Assessments { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Activity, ActivityDto>();
        }

    }
}
