using MenuAndOrder.Data.DatabaseEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndOrder.Data.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        //Seeding Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "Jollof Rice", Description = "Delicious party Jollof", Price = 1500, IsAvailable = true },
                new MenuItem { Id = 2, Name = "Chicken Suya", Description = "Spicy grilled chicken suya", Price = 2500, IsAvailable = true },
                new MenuItem { Id = 3, Name = "Zobo Drink", Description = "Refreshing hibiscus drink", Price = 800, IsAvailable = true }
            );
        }
    }
}
