using System;
using ORRA.Domain.Common;

namespace ORRA.Domain.Entities
{
    public class AssuranceRequest : AuditableEntity
    {
        public Guid Id { get; set; }
    }
}