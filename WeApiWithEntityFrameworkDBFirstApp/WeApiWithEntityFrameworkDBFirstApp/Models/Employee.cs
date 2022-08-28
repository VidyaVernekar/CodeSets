using System;
using System.Collections.Generic;

namespace WeApiWithEntityFrameworkDBFirstApp.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; } = null!;
        public decimal Salary { get; set; }
        public int? RolId { get; set; }

        public virtual Role? Rol { get; set; }
    }
}
