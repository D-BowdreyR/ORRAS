using System;
using ORRA.Domain.Common;

namespace ORRA.Domain.Entities
{
    public class Person : AuditableEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}