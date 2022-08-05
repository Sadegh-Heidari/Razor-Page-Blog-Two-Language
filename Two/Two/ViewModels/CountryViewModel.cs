using System.ComponentModel.DataAnnotations;

namespace Two.ViewModels
{
    public class CountryViewModel : IDisposable
    {
        public int id { get; set; }
        public IFormFile? imageCountry { get; set; }
        public string? imagePath { get; set; }

        [MaxLength(50, ErrorMessage = "حداکثر طول اسم کشور 50 کاراکتر است.")]
        [Required(ErrorMessage = "این فیلد اجباری است.")]
        public string? nameCountry { get; set; }
        [MaxLength(50, ErrorMessage = "حداکثر تعداد بازید تا 50 عدد میباشد.")]
        [Required(ErrorMessage = "این فیلد اجباری است.")]
        public string? visit { get; set; }
        [MaxLength(3, ErrorMessage = "برای تعین نوار درصد، حداکثر میتوانید 100 درصد وارد کنید")]
        [Required(ErrorMessage = "این فیلد اجباری است.")]
        public string? AriaProgress { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}