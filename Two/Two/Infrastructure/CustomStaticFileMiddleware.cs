using System.Net;
using System.Web;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;

namespace Two.Infrastructure
{
    public class CustomStaticFileMiddleware : object
    {
        private RequestDelegate _next { get; }
        private IHostEnvironment _environment { get; }

        public CustomStaticFileMiddleware(RequestDelegate requestDelegate, IHostEnvironment environment) : base()
        {
            _next = requestDelegate;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            var requestPath = httpContext.Request.Path.ToString();
            if (string.IsNullOrEmpty(requestPath) || requestPath == "/" || requestPath.StartsWith('/') == false)
            {
                await _next(httpContext);
                return;
            }

            var PathFile = requestPath[1..];
            var FullpathStaticFiles = Path.Combine(_environment.ContentRootPath, "wwwroot\\content", PathFile);
            if (string.IsNullOrEmpty(FullpathStaticFiles) == true || !File.Exists(FullpathStaticFiles))
            {
                await _next(httpContext);
                return;
            }

            var ContentType = MimeTypes.GetMimeType(FullpathStaticFiles);
            var FileName = Path.GetExtension(FullpathStaticFiles).ToLower();
            if (ContentType == null)
            {
                await _next(httpContext);
                return;
            }
            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = ContentType;
            await httpContext.Response.SendFileAsync(FullpathStaticFiles);
        }
    }
}
