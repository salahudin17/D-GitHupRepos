﻿using Demo.DataAccessLayer.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Rebositories
{

    //public class DepartmentRepository(ApplicationDbContext _dbContext) : GenericRepository<Department>, IDepartmentRepository
    
        public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
    {
        public DepartmentRepository( ApplicationDbContext context):base(context)
        {

        }
        #region Way 1
        //private readonly ApplicationDbContext _dbContext;

        //public DepartmentRepository(ApplicationDbContext dbContext)
        //{
        //    this._dbContext = dbContext;
        //}

        //CRUD Operations add delete
        //Get All

        //public IEnumerable<Department> GetAll(bool WithTraking = false)
        //{
        //    if (WithTraking)
        //        return _dbContext.Departments.ToList();
        //    else
        //        return _dbContext.Departments.AsNoTracking().ToList();


        //}
        ////Get by id
        //public Department? GetById(int id) => _dbContext.Departments.Find(id);

        ////Update
        //public int Update(Department department)
        //{
        //    _dbContext.Departments.Update(department);
        //    return _dbContext.SaveChanges();
        //}
        ////Delete
        //public int Remove(Department department)
        //{
        //    _dbContext.Departments.Remove(department);
        //    return _dbContext.SaveChanges();
        //}
        ////Insert
        //public int Add(Department department)
        //{
        //    _dbContext.Departments.Add(department);
        //    return _dbContext.SaveChanges();

        //}
        #endregion
        
    }
}
