using CSC_T.BusinessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSC_T.BusinessLayer
{
    public class CSCDbContext:IdentityDbContext<User>
    {
        public CSCDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Offering> Offerings { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CountryBusiness>()
                .HasKey(k => new { k.CountryId, k.BusinessId });

            modelBuilder.Entity<CountryBusiness>()
                .HasOne(cb => cb.Country)
                .WithMany(c => c.CountryBusiness)
                .HasForeignKey(cb => cb.CountryId);

            modelBuilder.Entity<CountryBusiness>()
                .HasOne(cb => cb.Business)
                .WithMany(b => b.CountryBusiness)
                .HasForeignKey(cb => cb.BusinessId);
        }
    }
}
