using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace ORRA.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;

        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                // valid Requests against all validators found
                var validationResults = await Task.WhenAll(_validators.Select(v => 
                    v.ValidateAsync(context, cancellationToken)));

                // collect failures if there where any
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                // if any validators provided failures, throw the ValidationException
                if(failures.Count != 0)
                    throw new ValidationException(failures);
            }
            return await next();
        }
    }
}