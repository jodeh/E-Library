using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.ComponentModel.DataAnnotations;

namespace e_library.Models
{
    public class Specialist
    {
        [Key]
        public int SpecialistId { get; set; }
        public string SpecialistName { get; set;}
        public string SpecialestImageurl { get; set; }
       
    }
}
