using e_library.Models;
using Microsoft.AspNetCore.Http;

namespace e_library.ViewModels
{
    public class SubjectFilesViewModel
    {
        public int SubjectFileId { get; set; }
        public string SubjectFileName { get; set; }
        public IFormFile File { get; set; }
        public string SubjectFileURLOthers { get; set; }
        public string SubjectDescription { get; set; }
        public int Type { get; set; }
        public int SubjectId { get; set; }
        public string SubjectFileURL { get; set; }

        public Subject Subjects { get; set; }

        public int LookupMediaTypeId { get; set; }
        public LookupMediaType LookupMediaType { get; set; }


    }
}
