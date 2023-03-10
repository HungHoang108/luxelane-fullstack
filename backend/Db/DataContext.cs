using Luxelane.Models;
using Luxelane.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Luxelane.Db
{
    public class DataContext : DbContext
    {

        static DataContext()
        {

            // You can also do that automatically using Reflection

            // Use the legacy timestamp behaviour - check Npgsql for more details
            // Recommendation from Postgres: Don't use time zone in database
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified && e.Entity is BaseModel);

            foreach (var entity in entities)
            {
                entity.Property("updatedAt").CurrentValue = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
        private readonly IConfiguration _config;
        public DataContext(DbContextOptions options, IConfiguration config) : base(options) => _config = config;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = _config.GetConnectionString("DefaultConnection");
            optionsBuilder
                .UseNpgsql(connString)
                .AddInterceptors(new DataContextSaveChangesInterceptor())
                .UseSnakeCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.HasPostgresEnum<UserRole>();
            var UserRoleConverter = new EnumToStringConverter<UserRole>();
            var OrderStatusConverter = new EnumToStringConverter<OrderStatus>();
            modelBuilder
                .Entity<User>()
                .Property(e => e.Role)
                .HasConversion(UserRoleConverter);

            modelBuilder
                .Entity<Order>()
                .Property(o => o.OrderStatus)
                .HasConversion(OrderStatusConverter);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                .Property(u => u.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //Many to many relationship Order and Product
            // modelBuilder.Entity<OrderProduct>()
            //     .HasKey(op => new { op.OrderId, op.ProductId });
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => op.Id);
            modelBuilder.Entity<OrderProduct>()
                .HasAlternateKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderProducts)
                .WithOne(op => op.Order)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderProducts)
                .WithOne(op => op.Product)
                .HasForeignKey(op => op.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            //Many to many relationship Product and Category
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<Category>()
                .HasMany(c => c.ProductCategories)
                .WithOne(pc => pc.Category)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductCategories)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().Navigation(item => item.Addresses).AutoInclude();
            modelBuilder.Entity<Order>().Navigation(item => item.OrderProducts).AutoInclude();
        }

        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

    }
}