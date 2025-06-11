using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Rebositories
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetALLAsync();
        Task<T>GetByIdAsync(int id);
        Task AddAsync(T item);
        void Update(T item);
        void Delete(T item);


    }
}
