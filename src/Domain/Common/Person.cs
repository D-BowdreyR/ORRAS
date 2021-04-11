using System;
using ORRA.Domain.Common;

namespace ORRA.Domain.Entities
{
    public abstract class Person : AuditableEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

    }
}