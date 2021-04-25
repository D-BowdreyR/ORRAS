using System;
using ORRAS.Domain.Common;

namespace ORRAS.Domain.Entities
{
    public class AssuranceRequest : AuditableEntity
    {
        public Guid Id { get; set; }
    }
}