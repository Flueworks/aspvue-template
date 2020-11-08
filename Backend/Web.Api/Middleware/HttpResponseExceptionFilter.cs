using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Api.Middleware
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            switch (context.Exception)
            {
                case NotFoundException _:
                    context.Result = new NotFoundResult();
                    context.ExceptionHandled = true;
                    break;
            }
        }
    }
}