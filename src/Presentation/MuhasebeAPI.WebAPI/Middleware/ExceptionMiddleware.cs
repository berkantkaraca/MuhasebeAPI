using FluentValidation;
using MuhasebeAPI.Application.Exceptions;
using MuhasebeAPI.Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace MuhasebeAPI.WebAPI.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
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

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        int statusCode = (int)HttpStatusCode.InternalServerError;
        string message = "Sunucu tarafında beklenmeyen bir hata oluştu.";
        List<string> errors = new List<string>();

        switch (exception)
        {
            case ValidationException e:
                statusCode = (int)HttpStatusCode.BadRequest;
                message = "Validasyon hataları oluştu.";
                errors = e.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}").ToList();
                break;

            case NotFoundException e:
                statusCode = (int)HttpStatusCode.NotFound;
                message = e.Message;
                errors.Add(exception.Message);
                break;

            case UnauthorizedAccessException:
                statusCode = (int)HttpStatusCode.Unauthorized;
                message = "Bu işlem için yetkiniz bulunmamaktadır.";
                errors.Add(exception.Message);
                break;

            case ConflictException e:
                statusCode = (int)HttpStatusCode.Conflict;
                message = e.Message;
                errors.Add("Mükerrer kayıt hatası.");
                break;

            case BadRequestException e:
                statusCode = (int)HttpStatusCode.BadRequest;
                message = e.Message;
                errors.Add(e.Message);
                break;

            default:
                errors.Add(exception.Message);
                break;
        }

        context.Response.StatusCode = statusCode;

        var response = new ApiResponse<string>(message, errors);

        var result = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return context.Response.WriteAsync(result);
    }
}
