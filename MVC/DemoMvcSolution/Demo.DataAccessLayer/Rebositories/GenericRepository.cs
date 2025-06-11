using Demo.DataAccessLayer.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Rebositories
{
   public class GenericRepository<T> : IGenericRepository<T>where T : class
    {

        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
            {
            _dbContext = dbContext;
            }
        public async Task AddAsync(T item)
        {
           await _dbContext.AddAsync(item);
            

        }

        public void Delete(T item)
        {
            _dbContext.Remove(item);
            
        }

        public async Task<IEnumerable<T>> GetALLAsync()
        {
            if(typeof(T)==typeof(Employee))
            {
                return (IEnumerable<T>) await _dbContext.Employees.Include(E => E.Department).ToListAsync();
            }
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        
            => await _dbContext.Set<T>().FindAsync(id);
        

        public void Update(T item)
        {
            _dbContext.Update(item);
            

        }
    }
}
