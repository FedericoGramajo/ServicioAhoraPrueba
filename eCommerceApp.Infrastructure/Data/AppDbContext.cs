using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.Cart;
using eCommerceApp.Domain.Entities.Identity;
using eCommerceApp.Domain.Entities.Rol;
using eCommerceApp.Domain.Entities.ServicioAhora;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace eCommerceApp.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ServiceStatus> ServiceStatuses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<AppUserAddress> UserAddresses { get; set; }
        public DbSet<ProfessionalLicense> ProfessionalLicenses { get; set; }
        public DbSet<ProfessionalGroup> ProfessionalGroups { get; set; }
        public DbSet<ProfessionalCategory> ProfessionalCategories { get; set; }
        public DbSet<ServiceOffering> ServiceOfferings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceDetail> ServiceDetails { get; set; }
        public DbSet<RatingService> RatingServices { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<CategoryOld> CategoriesOld { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Achieve> CheckoutAchieves { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Services → Customer
            builder.Entity<Service>()
                .HasOne(s => s.Customer)
                .WithMany() // o .WithMany(c => c.Services) si tenés colección
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Services → Professional
            builder.Entity<Service>()
                .HasOne(s => s.Professional)
                .WithMany() // o .WithMany(p => p.Services)
                .HasForeignKey(s => s.ProfessionalId)
                .OnDelete(DeleteBehavior.Restrict);


            // --- Herencia table-per-type para Customer y Professional ---
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Professional>().ToTable("Professionals");

            // --- Claves compuestas en tablas intermedias ----------------
            builder.Entity<AppUserAddress>()
                .HasKey(x => new { x.AppUserId, x.AddressId });

            builder.Entity<ProfessionalGroup>()
                .HasKey(x => new { x.GroupId, x.ProfessionalId });

            builder.Entity<ProfessionalCategory>()
                .HasKey(x => new { x.CategoryId, x.ProfessionalId });

            // --- Precisión de decimales y otras configuraciones ----------
            builder.Entity<ServiceOffering>()
                .Property(x => x.BasePrice)
                .HasColumnType("decimal(10,2)");

            builder.Entity<ServiceDetail>()
                .Property(x => x.UnitPrice)
                .HasColumnType("decimal(10,2)");

            // --- Relaciones (ejemplos) ----------------------------------
            builder.Entity<Service>()
                .HasMany(s => s.Details)
                .WithOne(d => d.Service)
                .HasForeignKey(d => d.ServiceId);

            builder.Entity<Service>()
                .HasMany(s => s.Ratings)
                .WithOne(r => r.Service)
                .HasForeignKey(r => r.ServiceId);

            builder.Entity<RatingService>(e =>
            {
                // FK principal: Service -> Ratings (podés dejar CASCADE)
                e.HasOne(r => r.Service)
                 .WithMany(s => s.Ratings)
                 .HasForeignKey(r => r.ServiceId)
                 .OnDelete(DeleteBehavior.Cascade);

                // Cortar cascada para evitar multiple paths:
                e.HasOne(r => r.Customer)
                 .WithMany(c => c.Ratings) // o .WithMany()
                 .HasForeignKey(r => r.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict); // o SetNull

                e.HasOne(r => r.Professional)
                 .WithMany(p => p.Ratings) // o .WithMany()
                 .HasForeignKey(r => r.ProfessionalId)
                 .OnDelete(DeleteBehavior.Restrict); // o SetNull
            });

            builder.Entity<PaymentMethod>()
                .HasData(
                    new PaymentMethod
                    {
                        Id = Guid.Parse("f5a43dbc-5c5d-4e77-bdbf-037f8f9dd10d"),
                        Name = "Credit Card"
                    }
                );
            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Id = Guid.Parse("9e4f49fe-0786-44c6-9061-53d2aa84fab3").ToString(),
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Id = Guid.Parse("3a9d0c3b-4e59-4b5e-a2b7-45c7d07f91d4").ToString(),
                        Name = "User",
                        NormalizedName = "USER"
                    }
                );
        }
    }
}
