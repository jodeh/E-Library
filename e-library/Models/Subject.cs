using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace e_library.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectImageurl { get; set; }
        public int SpecialistId { get; set; }
        public Specialist Specialists { get; set; }

    }
}
