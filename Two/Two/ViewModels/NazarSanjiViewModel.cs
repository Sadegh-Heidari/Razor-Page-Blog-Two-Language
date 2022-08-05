using System.ComponentModel.DataAnnotations;

namespace Two.ViewModels
{
    public class NazarSanjiViewModel : IDisposable
    {

        public int Id { get; set; }
        public IFormFile? imagename { get; set; }
        [MaxLength(50, ErrorMessage = "حداکثر طول عنوان، 50 کاراکتر است.")]
        [Required(ErrorMessage = "این فیلد اجباری است.")]
        public string? title { get; set; }
        [MaxLength(500, ErrorMessage = "حداکثر طول توضیحات 500 کاراکتر است")]
        [Required(ErrorMessage = "این فیلد اجباری است.")]
        public string? Description { get; set; }
        public string? imagePath { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
