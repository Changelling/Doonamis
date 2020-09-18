using SilliconPower.Backend.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
