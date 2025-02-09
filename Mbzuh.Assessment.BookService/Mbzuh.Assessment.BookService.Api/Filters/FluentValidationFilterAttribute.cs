using Microsoft.AspNetCore.Mvc.Filters;

namespace Mbzuh.Assessment.BookService.Api.Filters;

public class FluentValidationFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                .SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToList();
            var response = new { success = false, message = string.Join(",", errors) };
            context.Result = new BadRequestObjectResult(response);
        }
    }
}
