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
        public class Query : IRequest<List<Company>>
        {
            //  this is where features like pagenation will go
        }

        public class Handler : IRequestHandler<Query, List<Company>>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Company>> Handle(Query request, CancellationToken cancellationToken)
            {
                var companies = await _context.Companies.ToListAsync(cancellationToken);

                return companies;
            }
        }
    }
}