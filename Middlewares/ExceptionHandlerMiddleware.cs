using System.Net;
using ExpenseCase.Infrastructure.Exceptions;

namespace ExpenseCase.Middlewares;

public class ExceptionHandleMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleException(ex, httpContext);
        }
    }

    private async Task HandleException(Exception exception, HttpContext httpContext)
    {


        if (exception is HttpException)
        {
            var httpException = exception as HttpException;
            httpContext.Response.StatusCode = (int)httpException.GetHttpStatusCode();
            if (exception is WritableBodyException ex)
            {
                httpContext.Response.StatusCode = (int)httpException.GetHttpStatusCode();
                if (ex.Errors.Any())
                {
                    await httpContext.Response
                        .WriteAsJsonAsync(ex.Errors);
                }
                else
                {
                    await httpContext.Response
                        .WriteAsJsonAsync(ex);
                }
            }
        }
        else
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsync(exception.Message);
        }


    }
}

public static class ExceptionHandleMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandleMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandleMiddleware>();
    }
}