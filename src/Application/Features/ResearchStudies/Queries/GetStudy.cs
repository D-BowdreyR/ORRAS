using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ORRAS.Application.Common.Exceptions;
using ORRAS.Application.Common.Interfaces;

namespace ORRAS.Application.Features.ResearchStudies.Queries
{
    public class GetStudy
    {
        public class Query : IRequest<ResearchStudyDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ResearchStudyDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public Handler(IApplicationDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }

            public async Task<ResearchStudyDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var study = await _context.ResearchStudies
                    .ProjectTo<ResearchStudyDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                    if(study == null) throw new NotFoundException("Study", request.Id);

                return study;
            }
        }
    }
}