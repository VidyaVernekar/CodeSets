using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmpolyeeDBFirst.Models;

namespace EmpolyeeDBFirst.Data
{
    public class EmpolyeeDBFirstContext : DbContext
    {
        public EmpolyeeDBFirstContext (DbContextOptions<EmpolyeeDBFirstContext> options)
            : base(options)
        {
        }

        public DbSet<EmpolyeeDBFirst.Models.EmployeeModel> EmployeeModel { get; set; } = default!;
    }
}
