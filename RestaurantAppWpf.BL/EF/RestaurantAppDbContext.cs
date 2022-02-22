using Microsoft.EntityFrameworkCore;
using RestaurantAppWpf.BL.Models;

namespace RestaurantAppWpf.BL.EF
{
    public class RestaurantAppDbContext : DbContext
    {
        public RestaurantAppDbContext() { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<TypeDish> TypeDishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CartItem> Cart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(LocalDb)\MSSQLLocalDB;database=RestaurantWpfDb;integrated security=True;
                    MultipleActiveResultSets=True;App=EntityFramework;");
        }
    }
}
