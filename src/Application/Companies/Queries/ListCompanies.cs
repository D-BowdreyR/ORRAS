using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            private readonly IMapper _mapper;
            public Handler(IApplicationDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<CompaniesVm> Handle(Query request, CancellationToken cancellationToken)
            {
                return new CompaniesVm
                {
                    Companies = await _context.Companies
                            .AsNoTracking()
                            .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                            .OrderBy(c => c.DisplayName)
                            .ToListAsync(cancellationToken)
                };

            }
        }
    }
}