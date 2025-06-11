using Demo.DataAccessLayer.Data.Contexts;
using Demo.DataAccessLayer.Models;
using Demo.DataAccessLayer.Rebositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*namespace Demo.BusniessLogicLayer.Services
{
    public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
    {
        //private readonly IDepartmentRepository departmentRepository;

        //public DepartmentService(IDepartmentRepository departmentRepository)
        //{
        //    this.departmentRepository = departmentRepository;
        //}

        //Get All
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var Departments = departmentRepository.GetAll();
            return Departments.Select(D => D.ToDto());
        }

        // Get Department By Id
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = departmentRepository.GetById(id);

            // Manual Mapping
            return department?.ToDetailsDto();
        }

        // Create New Department
        public int CreateDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return departmentRepository.Add(department);
        }


        // Updated Department
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return departmentRepository.Update(department);
        }

        // Delete Department
        public bool DeleteDepartment(int id)
        {
            var department = departmentRepository.GetById(id);
            if (department is null) return false;
            else
            {
                int Result = departmentRepository.Remove(department);
                if (Result > 0) return true;
                else return false;
            }
        }


    }
}*/
