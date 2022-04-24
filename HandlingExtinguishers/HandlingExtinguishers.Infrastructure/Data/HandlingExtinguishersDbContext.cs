using HandlingExtinguishers.DTO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HandlingExtinguishers.Infrastructure.Data
{
    public class HandlingExtinguishersDbContext : IdentityDbContext<ApplicationUser>
    {
        public HandlingExtinguishersDbContext(DbContextOptions<HandlingExtinguishersDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClientTable>? Client { get; set; }
        public DbSet<CompanyTable>? Company { get; set; }
        public DbSet<CreditServiceTable>? CreditService { get; set; }
        public DbSet<EmployeeTable>? Employee { get; set; }
        public DbSet<ExpenseTable>? Expense { get; set; }
        public DbSet<InventoryTable>? Inventory { get; set; }
        public DbSet<PriceTable>? Price { get; set; }
        public DbSet<ProductTable>? Product { get; set; }
        public DbSet<ServiceDetailtTable>? ServiceDetail { get; set; }
        public DbSet<ServiceTable>? Service { get; set; }
        public DbSet<TypeExtinguisherTable>? TypeExtinguisher { get; set; }
        public DbSet<WeightExtinguisherTable>? WeightExtinguisher { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientTable>().Property(e => e.Id).HasConversion<string>();

            modelBuilder.Entity<CompanyTable>().Property(e => e.Id).HasConversion<string>();

            modelBuilder.Entity<ExpenseTable>().Property(e => e.Id).HasConversion<string>();

            modelBuilder.Entity<EmployeeTable>().Property(e => e.Id).HasConversion<string>();
            modelBuilder.Entity<EmployeeTable>().Property(e => e.CompanyId).HasConversion<string>();

            modelBuilder.Entity<PriceTable>().Property(e => e.Id).HasConversion<string>();

            modelBuilder.Entity<TypeExtinguisherTable>().Property(e => e.Id).HasConversion<string>();

            modelBuilder.Entity<WeightExtinguisherTable>().Property(e => e.Id).HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }


    }
}
