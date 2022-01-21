using BarisTutakli.WebApi.Services.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.Middleswares
{
    
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next,ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }
        public async Task Invoke(HttpContext context)
        {
            string message = "[Request HTTP]" + context.Request.Method + "--" + context.Request.Path;

            //Console.WriteLine(message);
            _loggerService.Write(message);
            await _next(context);
            message ="[Response HTTP]" + context.Request.Method + "--" + context.Request.Path+" responded "+context.Response.StatusCode;
            _loggerService.Write(message);
            //Console.WriteLine(message);
        }
       

    }
    public static class CustomExceptionMiddlewareExctension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
