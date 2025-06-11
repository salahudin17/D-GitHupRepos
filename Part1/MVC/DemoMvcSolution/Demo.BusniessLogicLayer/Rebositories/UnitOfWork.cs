using Demo.BusniessLogicLayer.Interfaces;
using Demo.DataAccessLayer.Data.Contexts;
using Demo.DataAccessLayer.Rebositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusniessLogicLayer.Rebositories
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        public IEmployeeRepository EmployeeRepository { get ; set ; }
        public IDepartmentRepository DepartmentRepository { get ; set ; }
        public ApplicationDbContext _dbContext { get; }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            EmployeeRepository = new EmployeeRebository(dbContext);
            DepartmentRepository = new DepartmentRepository(dbContext);
            _dbContext = dbContext;
        }


        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
