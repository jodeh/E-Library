using e_library.Data;
using System;
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

        public SubjectFiles Search(string entity)
        {
            throw new NotImplementedException();
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

        public object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

       

        List<SubjectFiles> IRepository<SubjectFiles>.Search(string entity)
        {
            throw new NotImplementedException();
        }
    }
}
