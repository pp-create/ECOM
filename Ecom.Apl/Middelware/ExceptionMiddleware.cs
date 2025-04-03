using Ecom.Apl.Helper;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Text.Json;

namespace Ecom.Apl.Middelware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environment;
        private readonly IMemoryCache _memoryCache;
        private readonly TimeSpan _rateLimitWindow=TimeSpan.FromSeconds(30);


        public ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment environment, IMemoryCache memoryCache)
        {
            _next = next;
            _environment = environment;
            this._memoryCache = memoryCache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                ApplySecurity(context);
                if (!IsRequestAllowed(context))
{
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    context.Response.ContentType = "application/json";

                   var response = new ApiExceptions(
    (int)HttpStatusCode.TooManyRequests, 
    "Too many requests. Please try again later.", 
    "" // Add a third argument here
);

                    await context.Response.WriteAsJsonAsync(response);
                    return; // إيقاف تنفيذ الـ Middleware بعد إرسال الاستجابة
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = _environment.IsDevelopment()
                    ? new ApiExceptions((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                    : new ApiExceptions((int)HttpStatusCode.InternalServerError, "An unexpected error occurred.");

                var json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json);
            }
        }
        private bool IsRequestAllowed(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress.ToString();
            var cachKey = $"Rate:{ip}";
            DateTime dateNow = DateTime.Now;

            var (timesTamp, count) = _memoryCache.GetOrCreate(cachKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = _rateLimitWindow;
                return (dateNow, 0);
            });

            if (dateNow - timesTamp > _rateLimitWindow)
            {
                _memoryCache.Set(cachKey, (dateNow, 1), absoluteExpirationRelativeToNow: _rateLimitWindow);
            }
            else
            {
                if (count >= 8)
                {
                    return false;
                }

                count++; // تحديث العداد قبل التعيين
                _memoryCache.Set(cachKey, (timesTamp, count), absoluteExpirationRelativeToNow: _rateLimitWindow);
            }

            return true;
        }
        public async Task ApplySecurity(HttpContext context)
        {
            context.Response.Headers["X-Content-Type-Options"] = "nosniff";
            context.Response.Headers["X-XSS-Protection"] = "1; mode=block";
            context.Response.Headers["X-Frame-Options"] = "DENY";

           
        }

    }
}
