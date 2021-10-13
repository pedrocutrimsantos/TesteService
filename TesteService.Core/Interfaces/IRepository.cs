using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TesteService.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(string search);
        Task<T> GetByIdAsync(Guid ID);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
