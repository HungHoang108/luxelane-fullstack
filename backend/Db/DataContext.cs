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
        private readonly IConfiguration _config;
        public DataContext(DbContextOptions options, IConfiguration config) : base(options) => _config = config;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = _config.GetConnectionString("DefaultConnection");
            optionsBuilder
                .UseNpgsql(connString)
                // .AddInterceptors(new AppDbContextSaveChangesInterceptor())
                .UseSnakeCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.HasPostgresEnum<UserRole>();
            var converter = new EnumToStringConverter<UserRole>();
            modelBuilder
                .Entity<User>()
                .Property(e => e.Role)
                .HasConversion(converter);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                .Property(u => u.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Address>()
                .HasOne<User>(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>().Navigation(s => s.Addresses).AutoInclude();
        }

        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}