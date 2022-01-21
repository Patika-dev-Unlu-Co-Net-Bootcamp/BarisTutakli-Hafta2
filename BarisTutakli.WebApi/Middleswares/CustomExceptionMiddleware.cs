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
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string message = "[Request HTTP]" + context.Request.Method + "--" + context.Request.Path;
            Console.WriteLine(message);
            await _next(context);
            message ="[Response HTTP]" + context.Request.Method + "--" + context.Request.Path+" responded"+context.Response.StatusCode;
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
