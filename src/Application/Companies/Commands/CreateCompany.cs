using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ORRAS.Application.Common.Interfaces;
using ORRAS.Domain.Entities;

namespace ORRAS.Application.Companies.Commands
{
    public class CreateCompany
    {
        public class Command : IRequest<Unit>
        {
            public Company Company { get; set; }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Companies.Add(request.Company);
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;
                return Unit.Value;
            }
        }
    }
}