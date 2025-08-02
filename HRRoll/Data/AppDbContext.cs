using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HRRoll.Models;
using HRRoll.Data; // Needed for AppUser

namespace HRRoll.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<ClientMaster> ClientMasters { get; set; }

        public DbSet<PayrollRecord> PayrollRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Required for Identity

            // Decimal precision settings
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<PayrollRecord>()
                .Property(p => p.GrossPay)
                .HasPrecision(18, 2);

            modelBuilder.Entity<PayrollRecord>()
                .Property(p => p.Deductions)
                .HasPrecision(18, 2);

            modelBuilder.Entity<PayrollRecord>()
                .Property(p => p.NetPay)
                .HasPrecision(18, 2);

            // Employee -> ClientMaster
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.ClientMaster)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.ClientMasterId)
                .OnDelete(DeleteBehavior.SetNull);

            // AppUser -> ClientMaster
            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.ClientMaster)
                .WithMany(c => c.Users)
                .HasForeignKey(a => a.ClientMasterId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
