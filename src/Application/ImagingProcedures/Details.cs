using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ORRA.Application.Common.Interfaces;
using ORRA.Domain.Entities;

namespace ORRA.Application.ImagingProcedures
{
    public class Details
    {
        public class Query : IRequest<ImagingProcedure> 
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ImagingProcedure>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<ImagingProcedure> Handle(Query request, CancellationToken cancellationToken)
            {
                var procedures = await _context.ImagingProcedures.FindAsync(request.Id);

                return procedures;
            }
        }
    }
}