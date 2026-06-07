using Microsoft.VisualBasic;
using System.Net;
using UserDataCalculator.Application.Contracts;
using UserDataCalculator.Validators;

namespace UserDataCalculator.Middleware
{
    public class ApiKeyValidatorMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyValidatorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IApiKeyValidator apiKeyValidator)
        {

            string? apiKey = context.Request.Headers["x-api-key"];

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync("API KEY is Missing");
                return;
            }

            if (!apiKeyValidator.IsValidApiKey(apiKey!))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }   
            await _next(context);
        }
    }
}
