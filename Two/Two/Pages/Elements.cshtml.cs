using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RZ_TOW_LANG.BAL.Business;
using Two.ViewModels;

namespace Two.Pages
{
    public class ElementsModel : PageModel
    {
        private IBusinessCountry country { get; }
        public IEnumerable<CountryViewModel>? countryList;
        public ElementsModel(IBusinessCountry country)
        {
            this.country = country;
        }


        public void OnGet()
        {
            countryList = country?.GetCountryList()?.Select(x => new CountryViewModel
            {
                id = x.ID,
                AriaProgress = x.AriaProgress,
                imagePath = x.imageCountry,
                nameCountry = x.nameCountry,
                visit = x.visit,
            });
        }
    }
}
