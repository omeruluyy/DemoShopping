using DemoShopping.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoShopping
{
    public class DemoShoppingDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<List> ShoppingLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ShoppingListDB;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ListProduct>().HasKey(x => new { x.ProductID, x.ListID });
            modelBuilder.Entity<ListProduct>().HasOne(x => x.Product)
                .WithMany(x => x.Lists)
                .HasForeignKey(x => x.ProductID);
            modelBuilder.Entity<ListProduct>().HasOne(x => x.List)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ListID);

            modelBuilder.Entity<User>().HasKey(x => x.UserID);

            modelBuilder.Entity<UserRole>()
      .HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>()
             .HasOne(ur => ur.User)
             .WithMany(u => u.UserRoles)
             .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>()
              .HasOne(ur => ur.Role)
              .WithMany(u => u.UserRoles)
              .HasForeignKey(ur => ur.RoleId);
        }
    }
}
