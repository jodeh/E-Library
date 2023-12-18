using e_library.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace e_library.Models.Repositories
{
    public class SubjectRepository : IRepository<Subject>
    {
        AppDbContext Db;
        public SubjectRepository(AppDbContext db)
        {
            
            Db= db;
            

        }

        public void Add(Subject entity)
        {
            Db.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, Subject entity)
        {
            var data = Find(Id);
            Db.Subject.Remove(data);
            Db.SaveChanges();
        }

        public Subject Find(int Id)
        {
            var data = Db.Subject.SingleOrDefault(a => a.SubjectId == Id);
            return data;
        }

        
        public void Update(int Id, Subject entity)
        {
            Db.Subject.Update(entity);
            Db.SaveChanges();
        }

        public List<Subject> View()
        {
            return Db.Subject.ToList();
        }

        public object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        List<Subject> Search(string entity)
        {
            throw new NotImplementedException();
        }

        List<Subject> IRepository<Subject>.Search(string entity)
        {
            throw new NotImplementedException();
        }
    }
}