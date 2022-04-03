using HandlingExtinguishers.DTO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HandlingExtinguishers.Infrastructure
{
    public class HandlingExtinguishersDbContext : IdentityDbContext<ApplicationUser>
    {
        public HandlingExtinguishersDbContext(DbContextOptions<HandlingExtinguishersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client>? Client { get; set; }
        public DbSet<Company>? Company { get; set; }
        public DbSet<CreditService>? CreditService { get; set; }
        public DbSet<Employee>? Employee { get; set; }
        public DbSet<Expense>? Expense { get; set; }
        public DbSet<Inventory>? Inventory { get; set; }
        public DbSet<Price>? Price { get; set; }
        public DbSet<Products>? Product { get; set; }
        public DbSet<ServiceDetail>? ServiceDetail { get; set; }
        public DbSet<Service>? Service { get; set; }
        public DbSet<TypeExtinguisher>? TypeExtinguisher { get; set; }
        public DbSet<WeightExtinguisher>? WeightExtinguisher { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().Property(e => e.Id).HasConversion<string>();

            modelBuilder.Entity<Company>().Property(e => e.Id).HasConversion<string>();

            modelBuilder.Entity<Expense>().Property(e => e.Id).HasConversion<string>();

            modelBuilder.Entity<Employee>().Property(e => e.Id).HasConversion<string>();
            modelBuilder.Entity<Employee>().Property(e => e.CompanyId).HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }


    }
}
