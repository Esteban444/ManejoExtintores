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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Companies>().Property(e => e.IdCompany).HasConversion<string>();

            modelBuilder.Entity<Expenses>().Property(e => e.IdExpense).HasConversion<string>();

        }

        public virtual DbSet<Clients>? Clients { get; set; }
        public virtual DbSet<Companies>? Companies { get; set; }
        public virtual DbSet<CreditServices>? CreditServices { get; set; }
        public virtual DbSet<Employees>? Employees { get; set; }
        public virtual DbSet<Expenses>? Expenses { get; set; }
        public virtual DbSet<Inventories>? Inventories { get; set; }
        public virtual DbSet<Prices>? Prices { get; set; }
        public virtual DbSet<Products>? Products { get; set; }
        public virtual DbSet<ServiceDetails>? ServiceDetails { get; set; }
        public virtual DbSet<Services>? Services { get; set; }
        public virtual DbSet<TypeExtinguishers>? TypeExtinguishers { get; set; }
        public virtual DbSet<WeightExtinguishers>? WeightExtinguishers { get; set; }

    }
}
