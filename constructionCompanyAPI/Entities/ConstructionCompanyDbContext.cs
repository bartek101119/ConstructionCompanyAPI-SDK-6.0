using Microsoft.EntityFrameworkCore;

namespace constructionCompanyAPI.Entities
{
    public class ConstructionCompanyDbContext : DbContext
    {
        public ConstructionCompanyDbContext(DbContextOptions<ConstructionCompanyDbContext> options) : base(options)
        {

        }
        public DbSet<ConstructionCompany> ConstructionCompanies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CompanyOwner> CompanyOwners { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(n => n.Name)
                .IsRequired();

            modelBuilder.Entity<ConstructionCompany>(eb =>
            {
                eb.Property(x => x.LegalForm).IsRequired();
                eb.Property(x => x.Name).IsRequired().HasMaxLength(40);
                eb.Property(x => x.NIP).IsRequired();
                eb.Property(x => x.REGON).IsRequired();
                eb.Property(x => x.ContactEmail).IsRequired();
                eb.Property(x => x.ContactNumber).IsRequired();
                eb.Property(x => x.StartDate).HasPrecision(3);
            });

            modelBuilder.Entity<CompanyOwner>(eb =>
            {
                eb.Property(c => c.FullName).IsRequired().HasMaxLength(40);
                eb.Property(c => c.ContactNumber).IsRequired();
                eb.Property(c => c.FullName).HasColumnName("Full_Name");
            });

            modelBuilder.Entity<Employee>().Property(x => x.FullName).HasColumnName("Full_Name");

        }
    }
}
