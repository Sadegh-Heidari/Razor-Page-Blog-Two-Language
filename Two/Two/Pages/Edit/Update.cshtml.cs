using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ripository.DAL.Models;
using RZ_TOW_LANG.BAL.Business;
using Two.ViewModels;

namespace Two.Pages.Edit
{
    public class UpdateModel : PageModel
    {
        private readonly IWebHostEnvironment _webHost;
        private IBusinessNazar _business { get; }
        public NazarSanjiViewModel? NazarSanji { get; set; }
        public UpdateModel(IBusinessNazar business, IWebHostEnvironment _webHost)
        {
            this._webHost = _webHost;
            _business = business;
        }


        public void OnGet(NazarSanjiDTAT nazar)
        {

            NazarSanji = new NazarSanjiViewModel();
            NazarSanji.Id = nazar.ID;
            NazarSanji.Description = nazar.Description;
            NazarSanji.title = nazar.title;
            TempData["Image"] = nazar.imagename;

        }

        public async Task<IActionResult> OnPost(NazarSanjiViewModel nazarSanji)
        {

            if (nazarSanji.imagename?.FileName != null)
            {
                TempData["Image"] = nazarSanji.imagename.FileName;

            }

            if (nazarSanji.imagename == null)
            {
                TempData["Image"] = Resources.ProjectResource.DefualtProjectPartialImage;
                nazarSanji.imagePath = Resources.ProjectResource.DefualtProjectPartialImage;
            }
            if (ModelState.IsValid)
            {
                if (nazarSanji.imagename != null)
                {
                    var path = Path.Combine(_webHost.ContentRootPath, "wwwroot\\content", "pics",
                        nazarSanji.imagename!.FileName);
                    if (!System.IO.File.Exists(path))
                    {
                        using (var FileStream = new FileStream(path, FileMode.Create))
                        {
                            await nazarSanji.imagename.CopyToAsync(FileStream).ConfigureAwait(false);

                        }

                    }
                    nazarSanji.imagePath = nazarSanji.imagename.FileName;
                }
                TempData["ResultUpdate"] = _business.Update(nazarSanji.Id, nazarSanji.imagePath!, nazarSanji.title!, nazarSanji.Description!);
                if (TempData["ResultUpdate"]?.ToString() == string.Empty)
                {
                    return RedirectToPage("/Index");
                }
            }

            return Page();
        }
    }
}
