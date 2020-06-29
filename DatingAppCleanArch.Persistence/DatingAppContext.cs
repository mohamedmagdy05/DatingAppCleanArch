using DatingAppCleanArch.Domain.Entities;
using DatingAppCleanArch.Persistence.configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DatingAppCleanArch.Persistence
{
    public class DatingAppContext : DbContext
    {
        public DatingAppContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // modelBuilder.Entity<User>().HasKey(g => g.Id);

            //modelBuilder.Entity<User>()
            //    .Property(p => p.FristName)
            //    .HasMaxLength(50);



            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.Group)
            //    .WithMany(u=>u.Users)
            //    .HasForeignKey(u => u.GroupId);


        }
    }
}
