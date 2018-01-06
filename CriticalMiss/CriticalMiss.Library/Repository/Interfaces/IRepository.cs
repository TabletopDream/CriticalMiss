using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Repository.Interfaces
{
    public interface IRepository<T>
    {
        T GetById (int id);

        IEnumerable<T> GetAll ();

        void Add (T entity);

        void Update (T entity);

        void Delete (T entity);
    }
}
