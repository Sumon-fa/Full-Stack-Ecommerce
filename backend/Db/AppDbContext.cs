using Microsoft.EntityFrameworkCore;
using backend.Models;
using Npgsql;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace backend.Db;

public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    private readonly IConfiguration _config;

    static AppDbContext()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<Order.OrderStatus>();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public AppDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connString = _config.GetConnectionString("DefaultConnection");

        optionsBuilder.UseNpgsql(connString)
                            .AddInterceptors(new AppDbContextSaveChangesInterceptor())
                            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasPostgresEnum<Order.OrderStatus>();

        modelBuilder.Entity<Product>()
          .Property(s => s.CreatedAt)
          .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Product>()
            .Property(s => s.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Category>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Category>()
            .Property(s => s.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Order>()
        .Property(s => s.CreatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Order>()
            .Property(s => s.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<CartItem>()
      .Property(s => s.CreatedAt)
      .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<CartItem>()
            .Property(s => s.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");


        modelBuilder.Entity<Order>()
                    .HasIndex(o => o.Customer);

        modelBuilder.Entity<Product>()
                    .HasIndex(p => p.Name);

        modelBuilder.Entity<User>()
                    .HasIndex(u => u.Email).IsUnique();

        modelBuilder.Entity<IdentityRole<int>>()
                    .HasData(
                        new IdentityRole<int> { Id = 1, Name = "User", NormalizedName = "USER" },
                        new IdentityRole<int> { Id = 2, Name = "Admin", NormalizedName = "ADMIN" }
                    );

        modelBuilder.AddIdentityConfig();
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
}
