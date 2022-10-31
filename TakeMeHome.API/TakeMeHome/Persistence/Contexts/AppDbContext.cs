using Microsoft.EntityFrameworkCore;
using TakeMeHome.API.Shared.Extensions;
using TakeMeHome.API.TakeMeHome.Domain.Models;

namespace TakeMeHome.API.TakeMeHome.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderStatus> OrderStatus { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Users
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.FullName).IsRequired().HasMaxLength(100);
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(p => p.Password).IsRequired();
        builder.Entity<User>().Property(p => p.Email).IsRequired();
        builder.Entity<User>().Property(p => p.Country).IsRequired();
        builder.Entity<User>().Property(p => p.DateOfBirth).IsRequired();
        builder.Entity<User>().Property(p => p.Phone).IsRequired();
        builder.Entity<User>().Property(p => p.Description).IsRequired().HasMaxLength(200);
        builder.Entity<User>().Property(p => p.PhotoUrl).IsRequired();
        builder.Entity<User>().Property(p => p.Points).IsRequired();
        builder.Entity<User>().Property(p => p.IdNumber).IsRequired();
        
        //Relationships
        builder.Entity<User>()
            .HasMany(p => p.Orders)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        
        builder.Entity<OrderStatus>()
            .HasMany(p=>p.Orders)
            .WithOne(p=>p.Status)
            .HasForeignKey(p=>p.StatusId);

        //Orders
        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().HasKey(p => p.Id);
        builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().Property(p => p.OrderCode).IsRequired();
        builder.Entity<Order>().Property(p => p.OriginCountry).IsRequired().HasMaxLength(15);
        builder.Entity<Order>().Property(p => p.OrderDestination).IsRequired();
        builder.Entity<Order>().Property(p => p.RequestDate).IsRequired();
        builder.Entity<Order>().Property(p => p.DeadlineDate).IsRequired();
        builder.Entity<Order>().Property(p => p.CurrentProcess).IsRequired().HasMaxLength(4);

        //StatusOrder
        builder.Entity<OrderStatus>().ToTable("StatusOrder");
        builder.Entity<OrderStatus>().HasKey(p => p.Id);
        builder.Entity<OrderStatus>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<OrderStatus>().Property(p => p.Status).IsRequired().HasMaxLength(15);
        
        
        //App Naming Conventions
        builder.UseSnakeCaseNamingConvention();
    }
}