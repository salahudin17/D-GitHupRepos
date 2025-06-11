using Demo.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Xunit.Sdk;

namespace Demo.Persentation.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        
        public String? Name { get; set; }
        
        public int? Age { get; set; }
        
        public string? Address { get; set; }
      
        public string? Email { get; set; }
        
         
        public string? Phone { get; set; }

        
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        
        public DateTime HireDate { get; set; }
        
        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        #region Reltionships
        //[ForeignKey("Department")]
        //public int DepartmentId { get; set; }

        //[InverseProperty("Employees")]
        //public Department? Department { get; set; }
        ////Navigational Property
        [ForeignKey("Department")]
        [Required]
        public int DepartmentId { get; set; }

        public Department Department { get; set; } = null!;
        #endregion
    }
}
