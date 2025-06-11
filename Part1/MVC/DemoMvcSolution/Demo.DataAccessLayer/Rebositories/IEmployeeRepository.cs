using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Rebositories
{
     public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        IQueryable<Employee> GetEmployeesByAddress(string address);
        Task<IEnumerable<Employee>> GetEmployeesByName(string SearchValue);
    }
    
}
