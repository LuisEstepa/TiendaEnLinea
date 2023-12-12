using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TiendaContext: DbContext
    {
        public DbSet<Category> Categorias { get; set; }
        //public DbSet<Tarea> Tareas { get; set; }

        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options) { }
    }
}
