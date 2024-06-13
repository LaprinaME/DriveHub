using System;
using DriveHub.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DriveHub.DataContext
{
    public class DriveHubContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<FavoriteCar> FavoriteCars { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<CarService> CarServices { get; set; }
        public DbSet<Dealership> Dealerships { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarCompany> CarCompanies { get; set; }
        public DbSet<TestDriveRequest> TestDriveRequests { get; set; }


        public DriveHubContext(DbContextOptions<DriveHubContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
