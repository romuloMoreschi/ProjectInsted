using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using PontoServico.Application.ViewModels;

namespace PontoServico.Application.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var (statusCode, message) = GetExceptionDetails(ex);

        context.Response.StatusCode = (int)statusCode;

        var result = JsonSerializer.Serialize(new ResultViewModel { Message = message });
        await context.Response.WriteAsync(result);
    }

    private static (HttpStatusCode StatusCode, string Message) GetExceptionDetails(Exception ex)
    {
        return (HttpStatusCode.InternalServerError, ex.InnerException.Message);
    }
}
