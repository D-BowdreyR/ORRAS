using System;
using System.Collections.Generic;

namespace ORRA.Application.Companies.Queries
{
    public class CompanyDto
    {
        public CompanyDto()
        {
            Departments = new List<DepartmentDto>();
        }

        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Abbreviation { get; set; }
        public IList<DepartmentDto> Departments { get; set; }
    }
}