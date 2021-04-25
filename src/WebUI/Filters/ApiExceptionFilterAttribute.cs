using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ORRAS.Application.Common.Exceptions;

namespace ORRAS.WebUI.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly Dictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute()
        {
            // Register each custom exception type and its handler within a Dictionary
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                {typeof(ValidationException), HandleValidationException},
                {typeof(NotFoundException), HandleNotFoundException},
                {typeof(ForbiddenAccessException), HandleForbiddenAccessException}
            };
            

        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
            
            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            
            // if there is a corresponding handler registered for the type 
            // of exception thrown then invoke its method
            
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }
            
            // if model state is not valid then invoke the dedicated method
            
            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            var exceptionDetails = new ValidationProblemDetails(exception.Errors)
            {
                Type = "https://httpstatuses.com/400"
            };

            context.Result = new BadRequestObjectResult(exceptionDetails);

            context.ExceptionHandled = true;        
        }
        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            var exceptionDetails = new ValidationProblemDetails(context.ModelState)
            {
                Type = "https://httpstatuses.com/400"
            };

            context.Result = new BadRequestObjectResult(exceptionDetails);

            context.ExceptionHandled = true;
        }

        public void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;
            var exceptionDetails = new ProblemDetails()
            {
                Type = "https://httpstatuses.com/404",
                Title = "The specified resource was not found",
                Detail = exception.Message
            };

            context.Result = new NotFoundObjectResult(exceptionDetails);

            context.ExceptionHandled = true;
        }
        
        // TODO: Implement a HandleUnauthorizedAccessException Method and corresponding Exception class

        public void HandleForbiddenAccessException(ExceptionContext context)
        {
            var exception = context.Exception as ForbiddenAccessException;

            var exceptionDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status403Forbidden,
                Title = "Forbidden",
                Type = "https://httpstatuses.com/403"
            };

            context.Result = new ObjectResult(exceptionDetails)
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
            
            context.ExceptionHandled = true;

        }
        private void HandleUnknownException(ExceptionContext context)
        {
            var exceptionDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request",
                Type = "https://httpstatuses.com/500"
            };

            context.Result = new ObjectResult(exceptionDetails)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    
    }
}