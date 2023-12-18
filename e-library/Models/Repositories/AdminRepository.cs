using System;
using System.Collections.Generic;

namespace e_library.Models.Repositories
{
    public class AdminRepository : IRepository<Admin_info>
    {
        public void Add(Admin_info entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int Id, Admin_info entity)
        {
            throw new System.NotImplementedException();
        }

        public Admin_info Find(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Search(Admin_info entity)
        {
            throw new System.NotImplementedException();
        }

        public Admin_info Search(string entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, Admin_info entity)
        {
            throw new System.NotImplementedException();
        }

        public List<Admin_info> View()
        {
            throw new System.NotImplementedException();
        }

        public object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

       

        List<Admin_info> IRepository<Admin_info>.Search(string entity)
        {
            throw new NotImplementedException();
        }



        //Admin_info IRepository<Admin_info>.Search(Admin_info entity)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
