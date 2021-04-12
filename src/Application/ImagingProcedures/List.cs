using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ORRA.Application.Common.Interfaces;
using ORRA.Domain.Entities;

namespace ORRA.Application.ImagingProcedures
{
    public class List
    {
        public class Query : IRequest<List<ImagingProcedure>> {}

        public class Handler : IRequestHandler<Query, List<ImagingProcedure>>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<ImagingProcedure>> Handle(Query request, CancellationToken cancellationToken)
            {
                var procedures = await _context.ImagingProcedures.ToListAsync();

                return procedures;
            }
        }
    }
}