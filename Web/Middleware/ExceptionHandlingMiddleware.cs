﻿
using System.Text.Json;
using Application.Exceptions;
using Domain.Exceptions.Base;

namespace Web.Middleware
{
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
                _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e) 
            { 
                _logger.LogError(e, e.Message);

                await HandleExceptionAsync(context, e); 

            }
        }


        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = exception switch
            {
                BadRequestException or ValidationException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            var errors = Array.Empty<ApiError>();

            if (exception is ValidationException validationException) 
            { 

                errors = validationException.Errors.SelectMany(kvp => kvp.Value, (kvp, value) => new ApiError(kvp.Key, value)).ToArray();   


            }

            var response = new
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = exception.Message,
                Errors = errors
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize( response ));

        }

        private record ApiError(string PropertyName, string ErrorMessage);
    }
}
