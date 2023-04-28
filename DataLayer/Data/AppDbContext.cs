using Bogus;
using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        //        .EnableSensitiveDataLogging(true)
        //        .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WineStore;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DataSeeding dataSeeder = new DataSeeding();

            modelBuilder.Entity<Product>().HasData(dataSeeder.Products);
            modelBuilder.Entity<Image>().HasData(dataSeeder.Images);
            modelBuilder.Entity<Category>().HasData(dataSeeder.Categories);
            modelBuilder.Entity<Country>().HasData(dataSeeder.Countries);
            modelBuilder.Entity<Basket>().HasData(dataSeeder.Baskets);
            modelBuilder.Entity<BasketItem>().HasData(dataSeeder.BasketItems);
            modelBuilder.Entity<Brand>().HasData(dataSeeder.Brands);
            modelBuilder.Entity<ProductCategory>().HasData(dataSeeder.ProductCategories);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(bc => new { bc.ProductId, bc.CategoryId });
            modelBuilder.Entity<ProductCategory>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.ProductCategories)
                .HasForeignKey(bc => bc.ProductId);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(bc => bc.CategoryId);

            this.SeedUsers(modelBuilder);
            this.SeedRoles(modelBuilder);
            this.SeedUserRoles(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }

        private void SeedUsers(ModelBuilder builder)
        {
            User user = new User()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            passwordHasher.HashPassword(user, "Test123!");

            builder.Entity<User>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "HR", ConcurrencyStamp = "2", NormalizedName = "Human Resource" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }
    }

}
