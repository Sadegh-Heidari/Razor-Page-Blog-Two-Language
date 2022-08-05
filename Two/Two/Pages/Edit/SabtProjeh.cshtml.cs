using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RZ_TOW_LANG.BAL.Business;
using Two.ViewModels;

namespace Two.Pages.Edit
{
    public class SabtNazarModel : PageModel
    {
        public NazarSanjiViewModel? NazarSanji { get; set; }
        private IBusinessNazar _businessNazar { get; }
        private IWebHostEnvironment _webHost { get; }
        public SabtNazarModel(IBusinessNazar businessNazar, IWebHostEnvironment webHost)
        {
            _businessNazar = businessNazar;
            _webHost = webHost;
            NazarSanji = new NazarSanjiViewModel();
        }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(NazarSanjiViewModel NazarSanji)
        {

            if (NazarSanji.imagename == null)
            {
                NazarSanji.imagePath = Resources.ProjectResource.DefualtProjectPartialImage;
            }
            if (ModelState.IsValid)
            {
                if (NazarSanji.imagename != null)
                {
                    var path = Path.Combine(_webHost.ContentRootPath, "wwwroot\\content", "pics",
                        NazarSanji.imagename!.FileName);
                    if (!System.IO.File.Exists(path))
                    {
                        using (var FileStream = new FileStream(path, FileMode.Create))
                        {
                            await NazarSanji.imagename.CopyToAsync(FileStream).ConfigureAwait(false);

                        }
                    }

                    NazarSanji.imagePath = NazarSanji.imagename.FileName;
                }
                _businessNazar.Add(NazarSanji.imagePath!, NazarSanji.title!, NazarSanji.Description!);
                return RedirectToPage("/Index");


            }

            return Page();
        }


    }
}
