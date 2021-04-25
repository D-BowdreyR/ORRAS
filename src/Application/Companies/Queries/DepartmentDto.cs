using System;

namespace ORRAS.Application.Companies.Queries
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public string Acronym { get; set; }
        public bool IsDefault { get; set; } = false;

    }
}