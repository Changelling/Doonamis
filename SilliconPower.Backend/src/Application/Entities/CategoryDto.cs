using AutoMapper;
using SilliconPower.Backend.Application.Common.Mappings;
using SilliconPower.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Application.Entities
{
    public class CategoryDto : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDto>();
        }
    }
}
