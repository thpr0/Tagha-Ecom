using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastosEcommercePlatform.Respository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetByeId(int Id);
        Task<bool> Add(T entity);
        Task<bool> Delete(int Id);
    }
}
