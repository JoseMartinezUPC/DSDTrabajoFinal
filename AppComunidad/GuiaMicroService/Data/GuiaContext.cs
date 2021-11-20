using GuiaMicroService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaMicroService.Data
{
    public class GuiaContext : DbContext
    {
        public GuiaContext(DbContextOptions<GuiaContext> options)
    : base(options)
        {
        }

        public DbSet<Bien> Bien { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Contacto> Contacto { get; set; }
    }
}
