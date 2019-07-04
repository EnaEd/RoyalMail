using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalMail.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Delete(int id);
        void Save(T item);
    }
}
