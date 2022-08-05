using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ripository.DAL.Models;
using Two.ViewModels;
using RZ_TOW_LANG.BAL.Business;

namespace Two.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string? CultureName { get; set; }
        private IBusinessNazar _businessNazar { get; }
        public IEnumerable<NazarSanjiDTAT>? Nazar { get; private set; }
        public IndexModel(IBusinessNazar businessNazar)
        {
            _businessNazar = businessNazar;
        }

        public void OnGet()
        {
            Nazar = _businessNazar.getAlList();

        }

        public IActionResult OnGetDelete(int id)
        {

            var x = _businessNazar.DeleteNazar(id);
            if (!string.IsNullOrWhiteSpace(x))
            {
                TempData["Delete"] = x;
            }
            return RedirectToPage("/Index");
        }

        public IActionResult OnGetCheckProjeh(int id)
        {
            var User = _businessNazar.getNazarById(id);

            if (User == null)
            {
                TempData["CheckProjeh"] = Resources.ProjectResource.DeleteProject;
                return RedirectToPage("./Index");
            }
            else
            {

                return RedirectToPage("./Edit/Update", User);
            }

        }

        public void OnGetSetCulture(string CultureName)
        {
            OnGet();
        }
    }
}
