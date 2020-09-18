using AutoMapper;
using SilliconPower.Backend.Application.Common.Mappings;
using SilliconPower.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Application.Entities
{
    public class BookingDto : IMapFrom<Booking>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int ActivityId { get; set; }
        public string UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Booking, BookingDto>();
        }
    }
}
