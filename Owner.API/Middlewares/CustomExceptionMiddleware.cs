using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Owner.API.Services;

namespace Owner.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = $"[Request] HTTP{context.Request.Method} -> {context.Request.Path}";
                _loggerService.write(message);
               
                await _next(context);
                watch.Stop();
                message =$"[Response] HTTP{context.Request.Method} -> {context.Request.Path} responded {context.Response.StatusCode} in {watch.Elapsed.TotalMilliseconds} ms";
                _loggerService.write(message);
                
                message = $"[WARNING] HTTP{context.Request.Method} -> {context.Request.Path} -> {context.Response.StatusCode} in {watch.Elapsed.TotalMilliseconds} ms -> Warning Message: Total milliseconds greather than 500";

                if (watch.Elapsed.TotalMilliseconds > 500)
                    _loggerService.write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "Application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            string message = $"[ERROR] HTTP{context.Request.Method} -> {context.Response.StatusCode} Error Message {ex.Message} in {watch.Elapsed.TotalMilliseconds} ms";
            _loggerService.write(message);

            var result = JsonSerializer.Serialize(new { error = ex.Message });
            return context.Response.WriteAsync(result);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}

