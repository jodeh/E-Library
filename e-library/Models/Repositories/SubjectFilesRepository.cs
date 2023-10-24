using e_library.Data;
using System.Collections.Generic;
using System.Linq;

namespace e_library.Models.Repositories
{
    public class SubjectFilesRepository : IRepository<SubjectFiles>
    {
        AppDbContext Db;
        public SubjectFilesRepository(AppDbContext db)
        {
            Db= db;
        }
        public void Add(SubjectFiles entity)
        {
            Db.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, SubjectFiles entity)
        {
            var data = Db.SubjectFiles.Find(Id);
            Db.SubjectFiles.Remove(data);
            Db.SaveChanges();
        }

        public SubjectFiles Find(int Id)
        {
            var data = Db.SubjectFiles.SingleOrDefault(a => a.SubjectFileId == Id);
            return data;
        }

        public void Update(int Id, SubjectFiles entity)
        {
            Db.SubjectFiles.Update(entity);
            Db.SaveChanges();
        }

        public List<SubjectFiles> View()
        {
            return Db.SubjectFiles.ToList();

        }
    }
}
