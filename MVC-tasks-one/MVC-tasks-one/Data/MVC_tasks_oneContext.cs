using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mcv_task1.Models;
using MVC_tasks_one.Models;

namespace MVC_tasks_one.Data
{
    public class MVC_tasks_oneContext : DbContext
    {
        public MVC_tasks_oneContext (DbContextOptions<MVC_tasks_oneContext> options)
            : base(options)
        {
        }

        public DbSet<mcv_task1.Models.Department> Department { get; set; } = default!;
        public DbSet<Employees> Employees { get; set; } = default!;
        public DbSet<MVC_tasks_one.Models.Managers> Managers { get; set; } = default!;
        public DbSet<Feedbacks> Feedbacks { get; set; } = default!;
        public DbSet<Tasks> Tasks { get; set; } = default!;
    }
}
