﻿using AutoMapper;
using SilliconPower.Backend.Application.Common.Mappings;
using SilliconPower.Backend.Domain.Entities;
using SilliconPower.Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Application.Entities
{
    public class LocationDto : IMapFrom<Location>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coordinate Coordinate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Location, LocationDto>();
        }
    }
}
