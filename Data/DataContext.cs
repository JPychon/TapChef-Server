using Microsoft.EntityFrameworkCore;
using TapChef_Backend.DTOs.Communication;
using TapChef_Backend.DTOs.Components;
using TapChef_Backend.DTOs.Identity;
using TapChef_Backend.DTOs.Media;
using TapChef_Backend.DTOs.Orders;
using TapChef_Backend.DTOs.Reviews;
using TapChef_Backend.DTOs.Utility;

namespace TapChef_Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Vendor> Vendors { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<MenuItem> MenuItems { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<Dish> Dishes { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<Certificate> Certificates { get; set; } = null!;
        public DbSet<Degree> Degrees { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Error> Errors { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Instruction> Instructions { get; set; } = null!;
        public DbSet<Note> Notes { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<ImageMetadata> Images { get; set; } = null!;
        public DbSet<VideoMetadata> Videos { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<ReviewableEntity> ReviewableEntities { get; set; } = null!;
        public DbSet<ReviewerEntity> ReviewerEntities { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Client
            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Address)
                .WithMany()
                .HasForeignKey(c => c.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.ProfilePicture)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ReviewableEntity>()
                .HasOne(re => re.Client)
                .WithOne(c => c.ReviewableEntity)
                .HasForeignKey<ReviewableEntity>(re => re.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReviewerEntity>()
                .HasOne(re => re.Client)
                .WithOne(c => c.ReviewerEntity)
                .HasForeignKey<ReviewerEntity>(re => re.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Vendor
            modelBuilder.Entity<Vendor>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Vendor>()
                .HasOne(v => v.Address)
                .WithMany()
                .HasForeignKey(v => v.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vendor>()
                .HasOne(v => v.ProfilePicture)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ReviewableEntity>()
                .HasOne(re => re.Vendor)
                .WithOne(c => c.ReviewableEntity)
                .HasForeignKey<ReviewableEntity>(re => re.VendorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReviewerEntity>()
                .HasOne(re => re.Vendor)
                .WithOne(c => c.ReviewerEntity)
                .HasForeignKey<ReviewerEntity>(re => re.VendorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Dish
            modelBuilder.Entity<Dish>()
                .HasOne(d => d.DisplayPicture)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Dish>()
                .HasOne(d => d.DisplayVideo)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            // Menu
            modelBuilder.Entity<Menu>()
                .HasOne(m => m.DisplayPicture)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            // MenuItem (Join entity for Menu and Dish many-to-many relationship)
            modelBuilder.Entity<MenuItem>()
                .HasKey(md => new { md.MenuId, md.DishId });

            modelBuilder.Entity<MenuItem>()
                .HasOne(md => md.Menu)
                .WithMany(m => m.MenuDishes)
                .HasForeignKey(md => md.MenuId);

            modelBuilder.Entity<MenuItem>()
                .HasOne(md => md.Dish)
                .WithMany()
                .HasForeignKey(md => md.DishId);

            // Recipe
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.DisplayPicture)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.DisplayVideo)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            // Error
            modelBuilder.Entity<Error>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e.Message);
                entity.Property(e => e.StackTrace);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.ErrorType).IsRequired().HasConversion<string>();
                entity.Property(e => e.Severity).IsRequired().HasConversion<string>();
            });

            // Payment
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.ClientId).IsRequired();
                entity.Property(p => p.Currency).IsRequired();
                entity.Property(p => p.Token);
                entity.Property(p => p.Method).IsRequired();
                entity.Property(p => p.Status).IsRequired().HasConversion<string>();

                // Relationships
                entity.HasOne(p => p.Transaction)
                      .WithOne(t => t.Payment)
                      .HasForeignKey<Payment>(p => p.TransactionId);

                entity.HasOne(p => p.Error)
                      .WithMany()
                      .HasForeignKey(p => p.ErrorId);
            });

            // Service
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Title).IsRequired();
                entity.Property(s => s.Description).IsRequired();
                entity.Property(s => s.Status).IsRequired().HasConversion<string>();

                // Relationships
                entity.HasOne(s => s.Address)
                      .WithMany()
                      .HasForeignKey(s => s.AddressId);

                entity.HasOne(s => s.Vendor)
                      .WithMany()
                      .HasForeignKey(s => s.VendorId);

                entity.HasOne(s => s.Client)
                      .WithMany()
                      .HasForeignKey(s => s.ClientId);

                entity.HasMany(s => s.Tags)
                      .WithMany();

                entity.HasMany(s => s.Notes)
                      .WithMany();
            });

            // Transaction
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Status).IsRequired().HasConversion<string>();

                // Relationships
                entity.HasOne(t => t.Payment)
                      .WithOne(p => p.Transaction)
                      .HasForeignKey<Transaction>(t => t.PaymentId);

                entity.HasOne(t => t.Service)
                      .WithMany()
                      .HasForeignKey(t => t.ServiceId);

                entity.HasOne(t => t.Error)
                      .WithMany()
                      .HasForeignKey(t => t.ErrorId);

                entity.HasMany(t => t.Tags)
                      .WithMany();

                entity.HasMany(t => t.Notes)
                      .WithMany();
            });
            
            // Tag
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Value).IsRequired();
            });

            // Note
            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(n => n.Id);
                entity.Property(n => n.Value).IsRequired();
            });

            // Instruction
            modelBuilder.Entity<Instruction>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Value).IsRequired();
            });

            // Address
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Street).IsRequired();
                entity.Property(a => a.City).IsRequired();
                entity.Property(a => a.State).IsRequired();
                entity.Property(a => a.PostalCode).IsRequired();
                entity.Property(a => a.Country).IsRequired();
            });

            // ImageMetadata
            modelBuilder.Entity<ImageMetadata>().HasKey(im => im.Id);

            // VideoMetadata
            modelBuilder.Entity<VideoMetadata>().HasKey(vm => vm.Id);

            // Review
            modelBuilder.Entity<Review>()
                .HasOne(r => r.TargetEntity)
                .WithMany(te => te.TargetedReviews)
                .HasForeignKey(r => r.TargetEntityId)
                .IsRequired();

            modelBuilder.Entity<Review>()
                .HasOne(r => r.OriginEntity)
                .WithMany(oe => oe.OriginatedReviews)
                .HasForeignKey(r => r.OriginEntityId)
                .IsRequired();

            // ReviewableEntity
            modelBuilder.Entity<ReviewableEntity>()
                .HasOne(re => re.Client)
                .WithOne(c => c.ReviewableEntity)
                .HasForeignKey<ReviewableEntity>(re => re.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ReviewableEntity>()
                .HasOne(re => re.Vendor)
                .WithOne(c => c.ReviewableEntity)
                .HasForeignKey<ReviewableEntity>(re => re.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // ReviewerEntity
            modelBuilder.Entity<ReviewerEntity>()
                .HasOne(re => re.Client)
                .WithOne(c => c.ReviewerEntity)
                .HasForeignKey<ReviewerEntity>(re => re.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ReviewerEntity>()
                .HasOne(re => re.Vendor)
                .WithOne(v => v.ReviewerEntity)
                .HasForeignKey<ReviewerEntity>(re => re.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // Message Configuration

            modelBuilder.Entity<Message>()
                .Property(m => m.Content)
                .IsRequired();
        }
    }
}
