using System;
using System.Collections.Generic;
using ORRA.Domain.Common;

namespace ORRA.Domain.Entities
{
    public class Company : AuditableEntity
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Abbreviation { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}