using Ecom.core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ecom.infrastructure.Data
{
   public class AppDBcontext:DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {
        }

        // DbSet<T> properties represent tables in the database
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<photo> photo { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(AppDBcontext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
           
        }

    }
}
