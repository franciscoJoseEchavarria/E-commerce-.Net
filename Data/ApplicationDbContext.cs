using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuevoProyecto.API.Models;
using Microsoft.EntityFrameworkCore; // Esta importación falta



namespace NuevoProyecto.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shipping> Shippings { get; set; }

        // Configure relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Añade esta línea
            
            // Configura la relación Order-OrderItem
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId);
            
            // Configura la relación Product-Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey("CategoryId");
                
            // Configura tipos de datos específicos
            modelBuilder.Entity<Product>()
                .Property(p => p.Price);
        }

       
    }
}