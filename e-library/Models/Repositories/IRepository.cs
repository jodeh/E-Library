using System;
using System.Collections.Generic;

namespace e_library.Models.Repositories
{
    public interface IRepository<TEntity>
    {
        List<TEntity> View();

        void Add(TEntity entity);

        void Update(int Id, TEntity entity);

        void Delete(int Id, TEntity entity);

        TEntity Find(int Id);
        object Where(Func<object, bool> value);
        List<TEntity> Search(string entity);

    }
}

