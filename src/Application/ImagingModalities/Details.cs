using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ORRA.Application.Common.Interfaces;
using ORRA.Domain.Entities;

namespace ORRA.Application.ImagingModalities
{
    public class Details
    {
        public class Query : IRequest<ImagingModality>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ImagingModality>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;

            }
            public async Task<ImagingModality> Handle(Query request, CancellationToken cancellationToken)
            {
                var modality = await _context.ImagingModalities.FindAsync(request.Id);
                return modality;
            }
        }
    }
}