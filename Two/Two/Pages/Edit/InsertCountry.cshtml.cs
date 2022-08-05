using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RZ_TOW_LANG.BAL.Business;
using Two.ViewModels;

namespace Two.Pages.Edit
{
    public class InsertCountryModel : PageModel
    {
        private IBusinessCountry country { get; }
        public IWebHostEnvironment WebHost { get; }
        public CountryViewModel Country { get; }
        public InsertCountryModel(IBusinessCountry country, IWebHostEnvironment _webHost)
        {
            this.country = country;
            WebHost = _webHost;
            Country = new CountryViewModel();
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(CountryViewModel Country)
        {

            if (Country.imageCountry == null)
            {
                Country.imagePath = Resources.ProjectResource.DefualtCountryPartialImage;
            }
            if (ModelState.IsValid)
            {
                if (Country.imageCountry != null)
                {
                    var path = Path.Combine(WebHost.ContentRootPath, "wwwroot\\content", "pics",
                        Country.imageCountry!.FileName);
                    if (!System.IO.File.Exists(path))
                    {
                        using (var FileStream = new FileStream(path, FileMode.Create))
                        {
                            await Country.imageCountry.CopyToAsync(FileStream).ConfigureAwait(false);

                        }
                    }

                    Country.imagePath = Country.imageCountry.FileName;
                }

                country.Add(Country.imagePath!, Country.nameCountry!, Country.visit!, Country.AriaProgress!);
                return RedirectToPage("/Elements");

            }

            return Page();
        }
    }
}
