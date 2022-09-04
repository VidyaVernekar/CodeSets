using System;
using System.Collections.Generic;

namespace WebAPIWithDBFirst.Models
{
    public partial class CompanyDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DepartmentId { get; set; }
        public string Address { get; set; } = null!;

        public virtual Department Department { get; set; } = null!;
    }
}
