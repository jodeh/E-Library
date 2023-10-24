using e_library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.Generic;
using System.Linq;

namespace e_library.Models.Repositories
{
    public class SpecialestRepository : IRepository<Specialist>
    {
        AppDbContext Db;

        public SpecialestRepository(AppDbContext db)
        {
            Db = db;
        }
        
        public void Add(Specialist entity)
        {
            Db.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, Specialist entity)
        {
            var data = Db.Specialist.Find(Id);
            Db.Specialist.Remove(data);
            Db.SaveChanges();
        }

        public Specialist Find(int Id)
        {
            var data = Db.Specialist.SingleOrDefault(a => a.SpecialistId == Id);
            return data;
        
        }

        public void Update(int Id, Specialist entity)
        {
            Db.Specialist.Update(entity);
            Db.SaveChanges();
        }

        public List<Specialist> View()
        {
            return Db.Specialist.ToList();
        }
    }
}
