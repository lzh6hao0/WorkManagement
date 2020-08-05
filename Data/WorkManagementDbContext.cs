using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Entites;

namespace WorkManagement.Data
{
    public class WorkManagementDbContext:DbContext
    {
        public WorkManagementDbContext(DbContextOptions<WorkManagementDbContext> options) 
            : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

      
    }
}
