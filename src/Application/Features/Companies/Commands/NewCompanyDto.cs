using System;

namespace ORRAS.Application.Features.Companies.Commands
{
    public class NewCompanyDto
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Abbreviation { get; set; }

    }
}