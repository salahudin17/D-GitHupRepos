using Demo.DataAccessLayer.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Rebositories
{
    public class EmployeeRebository : GenericRepository<Employee>, IEmployeeRepository
    {
        #region Way 1
        /*
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRebository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Employee employee)
        {
            _dbContext.Add(employee);
           return _dbContext.SaveChanges();
        }

        public int Delete(Employee employee)
        {
            _dbContext.Remove(employee);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetALL()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetById(int Id)
        {
            return _dbContext.Employees.Find(Id);
        }

        public int Update(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            return _dbContext.SaveChanges();
        }*/
        #endregion
        private readonly ApplicationDbContext _context;    
        public EmployeeRebository( ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public IQueryable<Employee> GetEmployeesByAddress(string address)
        {
            return _context.Employees.Where(e => e.Address == address);
        }

        //public IQueryable<Employee> GetEmployeesByName(string SearchValue)
        //{
        //    return _context.Employees.Where(E => E.Name.ToLower().Contains(SearchValue.ToLower()));
        //}
        public async Task<IEnumerable<Employee>> GetEmployeesByName(string SearchValue)
        {
            return await _context.Employees
                                 .Where(e => e.Name.ToLower().Contains(SearchValue.ToLower()))
                                 .ToListAsync();
        }

    }
}
