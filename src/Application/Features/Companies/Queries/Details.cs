using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ORRAS.Application.Common.Exceptions;
using ORRAS.Application.Common.Interfaces;
using ORRAS.Domain.Entities;

namespace ORRAS.Application.Features.Companies.Queries
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
                var company = await _context.Companies.FindAsync(request.Id, cancellationToken);

                if (company == null) 
                {
                    throw new NotFoundException("Company", request.Id);
                }

                return company;
            }
        }
    }
}