using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace thirdhandson.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var error = context.Exception;

            File.AppendAllText("logs.txt", 
                $"[{DateTime.Now}] Exception: {error.Message}{Environment.NewLine}");

            context.Result = new ObjectResult("Internal Server Error occurred")
            {
                StatusCode = 500
            };
        }
    }
}
