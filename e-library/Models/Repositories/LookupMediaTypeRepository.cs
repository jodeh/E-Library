using e_library.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace e_library.Models.Repositories
{
    public class LookupMediaTypeRepository : IRepository<LookupMediaType>
    {
        AppDbContext Db;
        public LookupMediaTypeRepository(AppDbContext db)
        {
            Db = db;
        }
        public void Add(LookupMediaType entity)
        {
            Db.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, LookupMediaType entity)
        {
            var data = Db.LookupMediaType.Find(Id);
            Db.LookupMediaType.Remove(data);
            Db.SaveChanges();
        }

        public LookupMediaType Find(int Id)
        {

            var data = Db.LookupMediaType.SingleOrDefault(a => a.LookupMediaTypeId == Id);
            return data;
        }

        public List< LookupMediaType> Search(string entity)
        {
            var result = Db.LookupMediaType.Where(a => a.LookupMediaTypeName == entity).ToList();
            return result;
        }

        public void Update(int Id, LookupMediaType entity)
        {
            Db.LookupMediaType.Update(entity);
            Db.SaveChanges();
        }

        public List<LookupMediaType> View()
        {
            return Db.LookupMediaType.ToList();
            

        }

        public object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

       

        List<LookupMediaType> IRepository<LookupMediaType>.Search(string entity)
        {
            throw new NotImplementedException();
        }
    }
}
