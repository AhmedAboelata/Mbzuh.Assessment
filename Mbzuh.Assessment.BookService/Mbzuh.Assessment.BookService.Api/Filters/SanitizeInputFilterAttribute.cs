using System.Reflection;
using Mbzuh.Assessment.BookService.Application.Common.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mbzuh.Assessment.BookService.Api.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SanitizeInputFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ActionArguments != null && actionContext.ActionArguments.Count == 1)
            {
                var requestParam = actionContext.ActionArguments.First();
                var properties = requestParam.Value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(x => x.CanRead && x.CanWrite && x.PropertyType == typeof(string));

                foreach (var propertyInfo in properties)
                {
                    //Sanitize spaces
                    propertyInfo.SetValue(requestParam.Value, ((string)propertyInfo.GetValue(requestParam.Value)).SanitizeSpaces());
                }
            }
        }
    }
}
