using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ORRA.Application.Common.Interfaces;
using ORRA.Domain.Entities;

namespace ORRA.Application.Companies.Queries
{
    public class ListCompanies
    {
        public class Query : IRequest<CompaniesVm>
        {
            //  this is where features like pagenation will go
        }

        public class Handler : IRequestHandler<Query, CompaniesVm>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<CompaniesVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var companies = await _context.Companies
                    .Include(d => d.Departments)
                    .ToListAsync(cancellationToken);

                IList<CompanyDto> companiesdtos = new List<CompanyDto>();

                foreach (var company in companies)
                {
                    IList<DepartmentDto> departdots = new List<DepartmentDto>();

                    foreach (var department in company.Departments)
                    {
                        departdots.Add(new DepartmentDto 
                        {   Id = department.Id, 
                            DepartmentName = department.DepartmentName,
                            Acronym = department.Acronym
                        });
                    }
                    
                    companiesdtos.Add(new CompanyDto
                    {   Id = company.Id, 
                        DisplayName = company.DisplayName,
                        Abbreviation = company.Abbreviation,
                        Departments = departdots
                    });
                }


                return new CompaniesVm
                {
                    Companies = companiesdtos
                };

            }
        }
    }
}