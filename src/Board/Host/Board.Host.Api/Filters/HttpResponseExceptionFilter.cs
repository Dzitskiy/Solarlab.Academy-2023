using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Board.Host.Api.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        private readonly ILogger<HttpResponseExceptionFilter> _logger;
        public HttpResponseExceptionFilter(ILogger<HttpResponseExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {

            if (context.Exception != null)
            {
                context.Result = new ObjectResult(new { message = "Ненормально!!!" })
                {
                    StatusCode = 500
                };
                _logger.LogError($"Произошла ошибка: {context.Exception.Message}");
            }
            context.ExceptionHandled = true;

        }
    }
}
