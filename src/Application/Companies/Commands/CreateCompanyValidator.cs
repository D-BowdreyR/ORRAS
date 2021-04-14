using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ORRA.Application.Common.Interfaces;

namespace ORRA.Application.Companies.Commands
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompany.Command>
    {
        private readonly IApplicationDbContext _context;
        public CreateCompanyValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Company.DisplayName)
                .NotEmpty().WithMessage("Company name is required")
                .MaximumLength(200).WithMessage("Company name must not exceed 200 characters.")
                .MustAsync(BeUniqueCompanyName).WithMessage("The specified company name already exists.");

            RuleFor(v => v.Company.Abbreviation)
                .MaximumLength(10).WithMessage("Company Abbreviation must not exceed 10 characters.");

        }

        private async Task<bool> BeUniqueCompanyName(string displayName, CancellationToken cancellationToken)
        {
            return await _context.Companies
                .AllAsync(c => c.DisplayName != displayName);
        }
    }
}