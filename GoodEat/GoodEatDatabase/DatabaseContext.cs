using GoodEatDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodEatDatabase
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var admin = new User
            {
                Id = 1,
                StartDate = DateTime.Now,
                FirstName = "john",
                LastName = "Doe",
                Email = "antoine.pinloche@admin.com",
                Password = "password",
                Username = "admin",
                UserRightID = 1,
            };
            var user = new User
            {
                Id = 2,
                StartDate = DateTime.Now,
                FirstName = "john",
                LastName = "Doe",
                Email = "antoine.pinloche@user.com",
                Password = "password",
                Username = "user",
                UserRightID = 2,
            };
            modelBuilder.Entity<User>().HasData(admin, user);

        }

    }
}
