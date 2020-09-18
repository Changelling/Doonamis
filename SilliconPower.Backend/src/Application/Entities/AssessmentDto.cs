using AutoMapper;
using SilliconPower.Backend.Application.Common.Mappings;
using SilliconPower.Backend.Domain.Entities;
using SilliconPower.Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Application.Entities
{
    public class AssessmentDto: IMapFrom<Assessment>
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public Rating Rating { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Assessment, AssessmentDto>();
        }
    }
}
