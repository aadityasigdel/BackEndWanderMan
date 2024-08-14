using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewProject.Models;

namespace NewProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions )
        :base (dbContextOptions)
        {
            
        }

        public DbSet <Hotel> Hotel { get; set; }
        public DbSet <Travel> Travel { get; set; }

        public DbSet <AppUser> Users {get; set;}

        public DbSet<HotelBookings> HotelBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HotelBookings>()
                .HasOne(hb => hb.Hotel)
                .WithMany(h => h.HotelBookings)
                .HasForeignKey(hb => hb.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HotelBookings>()
                .HasOne(hb => hb.User)
                .WithMany(u => u.HotelBookings)
                .HasForeignKey(hb => hb.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

            

            
        }
    }
}