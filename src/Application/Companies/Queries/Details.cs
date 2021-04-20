using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ORRA.Application.Common.Exceptions;
using ORRA.Application.Common.Interfaces;
using ORRA.Domain.Entities;

namespace ORRA.Application.Companies.Queries
{
    public class Details
    {
        public class Query : IRequest<Company>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Company>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Company> Handle(Query request, CancellationToken cancellationToken)
            {
                var company = await _context.Companies.FindAsync(request.Id);

                if (company == null) 
                {
                    throw new NotFoundException("Company", request.Id);
                }

                return company;
            }
        }
    }
}