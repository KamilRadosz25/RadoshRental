using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace RentCarApi.Entities
{
    public class RentalDbContext : DbContext
    {
        private string _connectionString = @"Server=KAMIL\SQLEXPRESS;Database=RadoshRental;Trusted_Connection=True;";

        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Car> Cars { get; set; }
        
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Rental>()
                .Property(r => r.StartDate)
                .IsRequired();
            modelBuilder.Entity<Car>()
                .Property(r => r.Model)
                .IsRequired()
                .HasMaxLength(40);
            modelBuilder.Entity<Brand>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(15);
            modelBuilder.Entity<Address>()
                .Property(x => x.City)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Address>()
                .Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(50);





        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
