using FTech.Domain.Entities.Auth;
using FTech.Domain.Entities.Cars;
using FTech.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;

namespace FTech.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }

        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
             => base.OnModelCreating(modelBuilder);
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-one relationship
            modelBuilder.Entity<Driver>()
                .HasOne(d => d.User)
                .WithOne(u => u.Driver)
                .HasForeignKey<Driver>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure foreign key relationship for Car and Category
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Cars)
                .HasForeignKey(c => c.CategoryId);

            // Configure the foreign key relationship for Car and Category
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Model = "SUV" },
                new Category { Id = 2, Model = "Sedan" }
            );

            // Seed data for Cars
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Name = "Car 1", Description = "Description 1", Number = "123ABC", Image = "image1.jpg", CategoryId = 1 },
                new Car { Id = 2, Name = "Car 2", Description = "Description 2", Number = "456DEF", Image = "image2.jpg", CategoryId = 2 }
            );
        }
    }
}
