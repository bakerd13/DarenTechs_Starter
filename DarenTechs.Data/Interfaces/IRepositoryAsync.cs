using DarenTechs.Data.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DarenTechs.Data.Interfaces
{
    public interface IRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(long id);
        Task<ICollection<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
