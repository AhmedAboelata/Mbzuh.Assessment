using Mbzuh.Assessment.BookService.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mbzuh.Assessment.BookService.Api.Filters;

internal class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        HandleException(context);
        base.OnException(context);
    }

    private static void HandleException(ExceptionContext context)
    {
        Type type = context.Exception.GetType();
        if (type == typeof(AlreadyExistsException))
            HandleAlreadyExistsException(context);
        else if (type == typeof(ObjectNotFoundException))
            HandleObjectNotFoundException(context);
        else
            HandleUnhandeledException(context);
    }

    private static void HandleAlreadyExistsException(ExceptionContext context)
    {
        var exception = (AlreadyExistsException)context.Exception;
        var response = new { success = false, exception.Message };
        context.Result = new ConflictObjectResult(response); //409
        context.ExceptionHandled = true;
    }

    private static void HandleObjectNotFoundException(ExceptionContext context)
    {
        var exception = (ObjectNotFoundException)context.Exception;
        var response = new { success = false, exception.Message };
        context.Result = new UnprocessableEntityObjectResult(response); //422
        context.ExceptionHandled = true;
    }

    private static void HandleUnhandeledException(ExceptionContext context)
    {
        var response = new { success = false, context.Exception.Message };
        context.Result = new ObjectResult(response) { StatusCode = 500 }; //500
    }
}
