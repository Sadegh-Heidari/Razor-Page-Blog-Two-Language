using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Two.Infrastructure;

namespace Two.Pages
{
    public class ChangeModel : PageModel
    {
        public ChangeModel(IOptions<RequestLocalizationOptions> options)
        {
            _options = options.Value;
        }

        private RequestLocalizationOptions? _options { get; }
        public IActionResult OnGet(string? CultureName)
        {
            var TypeHeader = HttpContext.Request.GetTypedHeaders();
            var httpReferer = TypeHeader?.Referer?.AbsoluteUri;
            if (String.IsNullOrWhiteSpace(httpReferer))
            {
              return RedirectToPage("/Index");
            }

            var SupportedList = _options!.SupportedCultures!.Select(x => x.Name).ToList();

            if (String.IsNullOrWhiteSpace(CultureName) || !SupportedList.Contains(item: CultureName))
            {
                CultureName = _options.DefaultRequestCulture.Culture.Name;
            }
            CookiCulture.SetCulture(CultureName);
            CookiCulture.CreatCookie(httpContext: HttpContext,CultureName);
            return Redirect(url: httpReferer);
        }
    }
}
