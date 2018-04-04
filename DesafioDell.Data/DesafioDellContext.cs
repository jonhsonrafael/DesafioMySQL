using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DesafioDell.Model;
using Microsoft.EntityFrameworkCore.Metadata;
using Pomelo.EntityFrameworkCore.MySql;

namespace DesafioDell.Data
{
    public class DesafioDellContext : DbContext
    {

              


        public DbSet<Customer> Customers { get; set; }
                
        public DesafioDellContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<Customer>()
                .Property(s => s.Id)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(s => s.Email)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(s => s.DateCreated)
                .HasDefaultValue(DateTime.Now);
            
        }
    }
}
