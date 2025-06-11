using Demo.DataAccessLayer.Rebositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusniessLogicLayer;

namespace Demo.BusniessLogicLayer.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        Task<int> CompleteAsync();
        void Dispose();
    }
}
