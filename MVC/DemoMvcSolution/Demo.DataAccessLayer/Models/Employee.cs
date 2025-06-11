using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Demo.DataAccessLayer.Models
{
   public  class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name IS Required !!")]
        [MaxLength(50,ErrorMessage ="Max Length Is 50 Chars !")]
        [MinLength(3,ErrorMessage = "Min Length Is 3 Chars !")]
        public  String? Name { get; set; }
        [Range(22,45,ErrorMessage ="Age Must Be In Range From 22 To 45 ")]
        public int? Age { get; set; }
        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$", ErrorMessage = "Address must be like 123-Street-City-Country")]

        public string? Address { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        [DataType(DataType.Currency)]
        public string? Phone { get; set; }
      
        [Precision(18, 2)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [DisplayName("Hiring Date")]
        public DateTime HireDate { get; set; }
        [DisplayName("Date Of Creation")]
        

        #region Reltionships
        //[ForeignKey("Department")]
        //public int DepartmentId { get; set; }

        //[InverseProperty("Employees")]
        //public Department? Department { get; set; }
        ////Navigational Property
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Department Department { get; set; } = null!;

        #endregion
    }
}
