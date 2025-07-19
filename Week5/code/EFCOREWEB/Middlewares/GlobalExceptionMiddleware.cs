using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace EFCOREWEB.Middlewares
{
  public class GlobalExceptionMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
      _next = next;
      _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"🔥 Exception caught :{ex.Message}");
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

                 var errorResponse = new
                {
                    statusCode = context.Response.StatusCode,
                    message = "An unexpected error occurred.",
               #if DEBUG
                    details = ex.Message
                 #endif
                };

                var json = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(json);



      }
    }
  }
}