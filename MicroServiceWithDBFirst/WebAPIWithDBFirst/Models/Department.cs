using System;
using System.Collections.Generic;

namespace WebAPIWithDBFirst.Models
{
    public partial class Department
    {
        public Department()
        {
            CompanyDetails = new HashSet<CompanyDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CompanyDetail> CompanyDetails { get; set; }
    }
}
