using Microsoft.AspNetCore.Http;

namespace e_library.ViewModels
{
    public class SpecialistViewModel
    {
        public int SpecialistId { get; set; }
        public string SpecialistName { get; set; }
        public string SpecialestImageurl { get; set; }
        public IFormFile File { get; set; }
    }
}
