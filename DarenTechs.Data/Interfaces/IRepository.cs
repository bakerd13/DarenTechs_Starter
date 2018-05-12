using DarenTechs.Data.Entities;
using System.Collections.Generic;

namespace DarenTechs.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(long id);
        ICollection<T> GetAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
