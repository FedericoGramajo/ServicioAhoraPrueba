using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.Cart;
using eCommerceApp.Domain.Entities.Identity;
using eCommerceApp.Domain.Entities.Rol;
using eCommerceApp.Domain.Entities.ServicioAhora;
using eCommerceApp.Domain.Interfaces;
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
                .WithMany() // o .WithMany(c => c.Services)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Services → Professional
            builder.Entity<Service>()
                .HasOne(s => s.Professional)
                .WithMany() // o .WithMany(p => p.Services)
                .HasForeignKey(s => s.ProfessionalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Customer>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).ValueGeneratedNever();
                e.HasOne(x => x.AppUser)
                 .WithOne(u => u.Customer)
                 .HasForeignKey<Customer>(x => x.Id)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Professional>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).ValueGeneratedNever();
                e.HasOne(x => x.AppUser)
                 .WithOne(u => u.Professional)
                 .HasForeignKey<Professional>(x => x.Id)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Professional>().ToTable("Professionals");

            builder.Entity<AppUserAddress>()
                .HasKey(x => new { x.AppUserId, x.AddressId });

            builder.Entity<ProfessionalGroup>()
                .HasKey(x => new { x.GroupId, x.ProfessionalId });

            builder.Entity<ServiceDetail>()
                .Property(x => x.UnitPrice)
                .HasColumnType("decimal(10,2)");

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
                e.HasOne(r => r.Service)
                 .WithMany(s => s.Ratings)
                 .HasForeignKey(r => r.ServiceId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(r => r.Customer)
                 .WithMany(c => c.Ratings)
                 .HasForeignKey(r => r.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(r => r.Professional)
                 .WithMany(p => p.Ratings)
                 .HasForeignKey(r => r.ProfessionalId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ServiceOffering>(b =>
            {
                // índices
                b.HasIndex(o => new { o.ProfessionalId, o.CategoryId });
                b.HasIndex(o => o.CategoryId);
                // opcional: único por nombre dentro del profesional
                // b.HasIndex(o => new { o.ProfessionalId, o.Name }).IsUnique();

                b.Property(x => x.BasePrice).HasColumnType("decimal(10,2)");
                b.Property(o => o.ProfessionalId).IsRequired();
                b.Property(o => o.CategoryId).IsRequired();

                // ⚠️ Cambiado a Restrict para evitar cascadas múltiples
                b.HasOne(o => o.Professional)
                 .WithMany(p => p.ServiceOfferings)
                 .HasForeignKey(o => o.ProfessionalId)
                 .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(o => o.Category)
                 .WithMany() // o .WithMany(c => c.ServiceOfferings)
                 .HasForeignKey(o => o.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);

                // FK compuesta → ProfessionalCategory (enforcement)
                b.HasOne<ProfessionalCategory>()
                 .WithMany()
                 .HasForeignKey(o => new { o.CategoryId, o.ProfessionalId })
                 .HasPrincipalKey(pc => new { pc.CategoryId, pc.ProfessionalId })
                 .OnDelete(DeleteBehavior.Restrict); // o .NoAction
            });

            builder.Entity<ProfessionalCategory>()
                .HasKey(x => new { x.CategoryId, x.ProfessionalId });

            builder.Entity<ProfessionalLicense>(b =>
            {
                // índices útiles
                b.HasIndex(x => new { x.ProfessionalId, x.CategoryId, x.Number }).IsUnique(); // evita duplicados
                b.HasIndex(x => x.CategoryId);

                // FK “normal”: License -> Professional
                b.HasOne(l => l.Professional)
                 .WithMany(p => p.Licenses)
                 .HasForeignKey(l => l.ProfessionalId)
                 .OnDelete(DeleteBehavior.Restrict); // evita multiple cascade paths

                // FK “normal”: License -> Category
                b.HasOne(l => l.Category)
                 .WithMany() // o .WithMany(c => c.ProfessionalLicenses) si agregás la colección
                 .HasForeignKey(l => l.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);

                // **ENFORCEMENT**: FK compuesta -> ProfessionalCategory
                b.HasOne<ProfessionalCategory>()
                 .WithMany()
                 .HasForeignKey(l => new { l.CategoryId, l.ProfessionalId })
                 .HasPrincipalKey(pc => new { pc.CategoryId, pc.ProfessionalId })
                 .OnDelete(DeleteBehavior.Restrict); // o NoAction
            });

            builder.Entity<ProfessionalCategory>(b =>
            {
                // PK compuesta (¡orden importa!)
                b.HasKey(pc => new { pc.CategoryId, pc.ProfessionalId });

                // Índices útiles
                b.HasIndex(pc => pc.ProfessionalId);
                b.HasIndex(pc => pc.CategoryId);

                // FK a Professional (RESTRICT para evitar multiple cascade paths)
                b.HasOne(pc => pc.Professional)
                 .WithMany(p => p.ProfessionalCategories)
                 .HasForeignKey(pc => pc.ProfessionalId)
                 .OnDelete(DeleteBehavior.Restrict);

                // FK a Category (RESTRICT también)
                b.HasOne(pc => pc.Category)
                 .WithMany(c => c.ProfessionalCategories)
                 .HasForeignKey(pc => pc.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<PaymentMethod>().HasData(
                new PaymentMethod
                {
                    Id = Guid.Parse("f5a43dbc-5c5d-4e77-bdbf-037f8f9dd10d"),
                    Name = "Credit Card"
                }
            );

            // Roles (typos corregidos)
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "ADMIN", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "PROFESSIONAL", Name = "Professional", NormalizedName = "PROFESSIONAL" },
                new IdentityRole { Id = "CUSTOMER", Name = "Customer", NormalizedName = "CUSTOMER" }
            );
        }

        public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            var now = DateTime.Now;

            foreach (var e in ChangeTracker.Entries<IAuditable>())
            {
                if (e.State == EntityState.Added)
                {
                    e.Entity.CreatedAt = now;
                    e.Entity.UpdatedAt = now;
                }
                else if (e.State == EntityState.Modified)
                {
                    e.Property(x => x.CreatedAt).IsModified = false; // nunca tocar CreatedAt
                    e.Entity.UpdatedAt = now;
                }
            }

            return await base.SaveChangesAsync(ct);
        }
    }

}
