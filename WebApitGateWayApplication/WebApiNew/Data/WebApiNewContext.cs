using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiNew.Models;

namespace WebApiNew.Data
{
    public class WebApiNewContext : DbContext
    {
        public WebApiNewContext (DbContextOptions<WebApiNewContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiNew.Models.Employee> Employee { get; set; } = default!;
    }
}
