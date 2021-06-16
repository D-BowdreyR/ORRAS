using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ORRAS.Application.Common.Interfaces;
using ORRAS.Domain.Entities;

namespace ORRAS.Application.Features.Companies.Commands
{
    public class CreateCompany
    {
        public class Command : IRequest<Unit>
        {
            public NewCompanyDto Company { get; set; }
        }

    public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public Handler(IApplicationDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var newcompany = _mapper.Map<Company>(request.Company);

                _context.Companies.Add(newcompany);

                // TODO: add exception handling for database save error
                // https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.savechangesasync?view=efcore-5.0
                _ = await _context.SaveChangesAsync(cancellationToken) > 0;

                return Unit.Value;
            }
        }
    }
}