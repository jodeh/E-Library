using System;
using System.ComponentModel.DataAnnotations;

namespace e_library.Models
{
    public class SubjectFiles
    {
        [Key]
        public int SubjectFileId { get; set; }
        public string SubjectFileName { get; set; }
        public string SubjectFileURL { get; set; }
        public string SubjectDescription { get; set; }
        public int Type { get; set; }
        public int SubjectId { get; set; }
        public Subject Subjects { get; set; }

    }
}
