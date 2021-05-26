using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ORRAS.Application.Common.Interfaces;

namespace ORRAS.Application.Features.ResearchStudies.Queries
{
    public class ListStudies
    {
        public class Query : IRequest<StudiesVm>
        {

        }

        public class Handler : IRequestHandler<Query, StudiesVm>
        {
            private readonly IMapper _mapper;
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public async Task<StudiesVm> Handle(Query request, CancellationToken cancellationToken)
            {
                return new StudiesVm
                {
                    Studies = await _context.ResearchStudies
                        .AsNoTracking()
                        .ProjectTo<ResearchStudyDto>(_mapper.ConfigurationProvider)
                        .OrderBy(c => c.Acronym)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}