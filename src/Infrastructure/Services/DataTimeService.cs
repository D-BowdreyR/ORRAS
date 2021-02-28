using System;
using ORRA.Application.Common.Interfaces;

namespace ORRA.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        // CHECK: would UTC time be a more appropriate convention to use?
        public DateTime Now => DateTime.Now;
    }
}