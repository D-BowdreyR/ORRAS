using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ORRAS.Application.Common.Interfaces;
using ORRAS.Domain.Entities;

namespace ORRAS.Application.Features.ImagingModalities
{
    public class List
    {
        public class Query : IRequest<List<ImagingModality>> { }

        public class Handler : IRequestHandler<Query, List<ImagingModality>>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;

            }

            public async Task<List<ImagingModality>> Handle(Query request, CancellationToken cancellationToken)
            {
                var modalities = await _context.ImagingModalities.ToListAsync(cancellationToken);

                return modalities;
            }
        }
    }
}