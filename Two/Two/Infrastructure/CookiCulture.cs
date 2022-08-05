using Microsoft.Extensions.Options;

namespace Two.Infrastructure
{
    public class CookiCulture
    {
        private RequestDelegate _next { get; }
        private RequestLocalizationOptions? Options { get; }

        #region Statics

        public static string Cooki = "Culture.Cookie";
        public static void SetCulture(string? CultureName)
        {
            if (!string.IsNullOrEmpty(CultureName))
            {
                var CultureInfo = new System.Globalization.CultureInfo(CultureName);
                Thread.CurrentThread.CurrentCulture = CultureInfo;
                Thread.CurrentThread.CurrentUICulture = CultureInfo;
            }
        }

        public static string? GetCooki(HttpContext httpContext, IList<string>? Supportedlist)
        {
            if (httpContext == null || Supportedlist == null || Supportedlist.Count == 0)
            {
                return null;
            }

            var GetCookki = httpContext.Request.Cookies[Cooki];
            if (String.IsNullOrWhiteSpace(GetCookki) || !Supportedlist.Contains(GetCookki))
            {
                return null;
            }
            return GetCookki;
        }

        public static void CreatCookie(HttpContext httpContext, string Culture)
        {
            var CookiOption = new CookieOptions
            {
                Secure = default,
                Expires = System.DateTimeOffset.UtcNow.AddMonths(1),
                HttpOnly = default,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Unspecified,
            };
            httpContext.Response.Cookies.Delete(Cooki);
            if (!String.IsNullOrWhiteSpace(Culture))
            {
                httpContext.Response.Cookies.Append(Cooki,Culture,CookiOption);
            }
        }
        #endregion

        public CookiCulture(RequestDelegate next, IOptions<RequestLocalizationOptions>? options) : base()
        {
            _next = next;
            Options = options?.Value;
        }

        public Task InvokeAsync(HttpContext httpContext)
        {
            var SupportedCulture = Options?.SupportedCultures?.Select(x=>x.Name).ToList();
            var CultureFinal = GetCooki(httpContext, SupportedCulture);
            if (String.IsNullOrWhiteSpace(CultureFinal))
            {
                CultureFinal = Options!.DefaultRequestCulture.Culture.Name;
            }
            SetCulture(CultureFinal);
            return _next(httpContext);
        }

       

    }
}
