using ManagementMicroService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementMicroService.Data
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions<ManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Menu> Menu { get; set; }
    }
}
