using e_library.Models;
using Microsoft.AspNetCore.Http;

namespace e_library.ViewModels
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectImageurl { get; set; }
        public IFormFile File { get; set; }
        public int SpecialistId { get; set; }
        public Specialist Specialists { get; set; }
    }
}
