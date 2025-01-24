using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KamathResidency.Infrastructure;

public partial class KamahResidencyContext : DbContext
{
    public KamahResidencyContext()
    {
    }

    public KamahResidencyContext(DbContextOptions<KamahResidencyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>()
             .HasMany(b => b.Rooms)
             .WithMany(r => r.Bookings)
             .UsingEntity<Dictionary<string, object>>(
                 "Booking_Room_Association",
                 b => b.HasOne<Room>().WithMany().HasForeignKey("RoomId"),
                 r => r.HasOne<Booking>().WithMany().HasForeignKey("BookingId")
             );

        // Configure default values and constraints
        modelBuilder.Entity<User>()
            .Property(u => u.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Room>()
            .Property(r => r.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Booking>()
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Booking>()
            .Property(b => b.ModifiedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
