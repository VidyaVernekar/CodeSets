using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCApplication.Models;

namespace MVCApplication.Data
{
    public class MVCApplicationContext : DbContext
    {
        public MVCApplicationContext (DbContextOptions<MVCApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<MVCApplication.Models.studentmodel> studentmodel { get; set; } = default!;
    }
}
