using eCommerce.Application.Common.Bases;
using eCommerce.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace eCommerce.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException)
            HandleErrorOnValidation(context);

        else if (context.Exception is ErrorNotFoundException)
            HandleErrorNotFound(context);

        else if (context.Exception is eCommerceException)
            HandleeCommerceException(context);

        else if (context.Exception is NotAuthorizedException)
            HandleNotAuthorizedException(context);

        else
            ThrowUnknowError(context);
    }

    private void HandleNotAuthorizedException(ExceptionContext context)
    {
        var validationErrors = (NotAuthorizedException)context.Exception;
        var response = new BaseResponseError(validationErrors.Errors);

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        context.Result = new ObjectResult(response);
    }

    private void HandleeCommerceException(ExceptionContext context)
    {
        var validationErrors = (eCommerceException)context.Exception;
        var response = new BaseResponseError(validationErrors.Errors);

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(response);
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        throw new NotImplementedException();
    }

    private void HandleErrorOnValidation(ExceptionContext context)
    {
        var validationErrors = (ErrorOnValidationException)context.Exception;
        var response = new BaseResponseError(validationErrors.Errors);

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(response);
    }

    private void HandleErrorNotFound(ExceptionContext context)
    {
        var validationErrors = (ErrorNotFoundException)context.Exception;
        var response = new BaseResponseError(validationErrors.Errors);

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(response);
    }
}
