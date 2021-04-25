using System;
using ORRAS.Application.Common.Interfaces;

namespace ORRAS.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        // CHECK: would UTC time be a more appropriate convention to use?
        public DateTime Now => DateTime.Now;
    }
}