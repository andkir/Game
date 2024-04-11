using System.Net;
using System.Text.Json;
using Game.Infrastructure.ExternalServices;
using Game.Domain.Exceptions;

namespace Game.API.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly ILogger<ErrorHandlerMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
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
        catch (Exception exception)
        {
            _logger.LogError(exception, "An error occured");
            context.Response.ContentType = "application/problem+json";

            context.Response.StatusCode = exception switch
            {
                UnexpectedResultException => (int)HttpStatusCode.BadRequest,
                InvalidChoiceException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var result = JsonSerializer.Serialize(
                new { context.Response.StatusCode, exception.Message },
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            await context.Response.WriteAsync(result);
        }
    }
}

