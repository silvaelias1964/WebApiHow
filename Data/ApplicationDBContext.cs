using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiHow.Models;



namespace WebApiHow.Data
{
    public class ApplicationDBContext : DbContext
    {

        /// <summary>
        /// Context de la aplicación
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        /// <summary>
        /// Tabla ingresos
        /// </summary>
        public DbSet<Ingresos> Ingresos  { get; set; }

        /// <summary>
        /// Tabla Casas relacionada con Ingresos
        /// </summary>
        public DbSet<Casas> Casas { get; set; }

        
    }
}
