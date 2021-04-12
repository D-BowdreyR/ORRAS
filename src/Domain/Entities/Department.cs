using System.Collections.Generic;
using System;
using ORRA.Domain.Common;

namespace ORRA.Domain.Entities
{
    public class Department : AuditableEntity
    {
        public Guid Id { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public string DepartmentName { get; set; }
        public string Acronym { get; set; }
        public bool IsDefault { get; set; } = false;
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
} 