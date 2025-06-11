using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Models
{
    public class Department:BaseEntity
    {
            public string Name { get; set; } = null!;
            public string Code { get; set; } = null!;
            public string? Description { get; set; }

        [InverseProperty("Department")]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();


        //[InverseProperty("Department")]
        //public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();//Navigational Property

    }
}

